using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mockup2.Tables;

namespace Mockup2
{
    /// <summary>
    /// The QueryBuilder class facilitates a more OO approach to constructing valid SQL queries. It employs the builder pattern to enable
    /// method chaining, which makes constructing a query a bit more natural.
    /// The methods that relate to SQL statements (SELECT, for instance) only allow Column objects to be passed in -
    /// this is to prevent spelling mistakes and other annoying bugs commonly found when heavily relying on strings.
    /// It should be noted that this class only supports a small subset of the full SQL specification, the smallest subset
    /// required for this project.
    /// Here is a small example of how to use this class:
    /// <code>
    /// QueryBuilder b = new QueryBuilder();
    /// b.Select(Tables.ALL).From(Tables.PATIENT_TABLE); // Selects everything from the Patient table
    /// string query = b.ToString();
    /// </code>
    /// Another example, that utilizes the Where clause to find staff who are doctors:
    /// <code>
    /// QueryBuilder b = new QueryBuilder();
    /// b.Select(Tables.ALL).From(Tables.STAFF_TABLE).Where(b.IsEquals(Tables.STAFF_TABLE.JobRole,"Doctor"));
    /// string query = b.ToString();
    /// </code>
    /// This class keeps a track of all queries it is asked to produce, as well as how many times each query is requested,
    /// for debug purposes. This will be useful in troubleshooting slow database queries; for example, somebody
    /// may have accidentally been creating and running queries in a loop.
    /// It should be noted that this class does not perform any form of error or sanity checking and will allow you to create nonsensical SQL queries
    /// provided you use valid Column and Table names, except in the case where the SQL query contains an Update statement.
    /// If an Update statement is present without a Where statement, an exception is thrown. This is due to the fact that
    /// updating an SQL table without specifying a Where clause will overwrite every row, causing irreperable data loss.
    /// </summary>
    public class QueryBuilder
    {
        private string query = "";
        private List<Column> selectedColumns = new List<Column>();
        private static Dictionary<string, int> pastQueries = new Dictionary<string, int>();

        /// <summary>
        /// Adds the supplied query to pastQueries dictionary, incrementing
        /// the number of times it has been created if it already exists.
        /// </summary>
        /// <param name="q">The query to add.</param>
        private void AddQuery(string q)
        {
            if (!pastQueries.ContainsKey(q))
            {
                pastQueries.Add(q, 0);
            }
            pastQueries[q]++;
        }

        public QueryBuilder Delete(Table table)
        {
            query += "DELETE FROM " + table.Name;
            return this;
        }

        /// <summary>
        /// Adds an Update statement to the current SQL query. Only supports updating
        /// one table at present. This can be easily changed later, if need be.
        /// This method MUST be paired with a Where method,
        /// else QueryBuilder will throw an exception. See the class description for more details.
        /// </summary>
        /// <param name="table">The Table to be updated.</param>
        /// <returns>This instance of QueryBuilder.</returns>
        public QueryBuilder Update(Table table)
        {
            query += "UPDATE " + table+" ";
            return this;
        }

        /// <summary>
        /// Adds an Insert statement to the current SQL query.
        /// </summary>
        /// <param name="table">The Table to be inserted into.</param>
        /// <returns>This instance of QueryBuilder.</returns>
        public QueryBuilder Insert(Table table)
        {
            query += "INSERT INTO " + table + " ";
            return this;
        }

        /// <summary>
        /// Adds a Values statement to the current SQL query.
        /// There are two ways to perform an insert in SQL - the first is to specify both column name and value,
        /// which allows you to leave some values out and have them default.
        /// The second is to not specify column names, but instead specify all values in the correct order.
        /// This method uses the latter, so ensure you supply ALL values for the given Table, and that they are the
        /// correct data type.
        /// </summary>
        /// <param name="values">The objects that will be used as values to insert into Table.</param>
        /// <returns>This instance of QueryBuilder.</returns>
        public QueryBuilder Values(params object[] values)
        {
            query += "VALUES (";
            foreach(object o in values)
            {
                if(o == null)
                {
                    query += "null, ";
                }else if(o is string)
                {
                    query += "'" + o + "', ";
                }
                else
                {
                    query += o + ", ";
                }
            }
            TrimQuery(2);
            query += ")";
            return this;
        }
        /// <summary>
        /// Adds a Set statement to the current SQL query. A word of warning for the parameters:
        /// to satisfy SQL, they must be pairs of Column and value. However, there is no way to enforce
        /// this and still have the amount supplied be variable (without creating a Tuple, or something similar),
        /// so please ensure you supply a Column and a value.
        /// </summary>
        /// <param name="o">Objects that correspond to pairs of Columns and values to be inserted into said Column.</param>
        /// <returns>This instance of QueryBuilder.</returns>
        public QueryBuilder Set(params object[] o)
        {
            query += "SET ";
            for (int i = 0; i < o.Count(); i += 2)
            {
                object o1 = o[i];
                object o2 = o[i + 1];
                if(o2 is Tables.Column)
                {
                    query += o1 + " = " + o2+", ";
                }
                else
                {
                    query += o1 + " = '" + o2 + "', ";
                }
            }
            TrimQuery(2);
            return this;
        }

        /// <summary>
        /// Returns the list of Columns that have been used in a Select method.
        /// </summary>
        /// <returns>A list of Columns.</returns>
        public List<Column> GetSelectedColumns()
        {
            return selectedColumns;
        }

        /// <summary>
        /// Adds a Select statement to the current SQL query.
        /// </summary>
        /// <param name="columns">The Columns to be selected from the Tables.</param>
        /// <returns>This instance of QueryBuilder.</returns>
        public QueryBuilder Select(params Column[] columns)
        {
            query += "SELECT ";
            foreach(Mockup2.Tables.Column c in columns)
            {
                if (c is AllColumn)
                {
                    query += c +",";
                }
                else
                {
                    query += c + " AS " + c.GetAs() + ",";
                }
                selectedColumns.Add(c);
            }
            TrimQuery(1);
            return this;
        }

        /// <summary>
        /// Convenience method to quickly trim the query string down by a specified amount of characters.
        /// Used to remove trailing characters such as commas from the ends of statements.
        /// </summary>
        /// <param name="amount">The amount of characters to trim from the end of the string.</param>
        private void TrimQuery(int amount)
        {
            query = query.Remove(query.Length - amount);
        }

        /// <summary>
        /// Adds a From statement to the current SQL query.
        /// </summary>
        /// <param name="tables">The tables to be used in the From statement.</param>
        /// <returns>This instance of QueryBuilder.</returns>
        public QueryBuilder From(params Table[] tables)
        {
            query += " FROM ";
            foreach(Table t in tables)
            {
                query += t + ",";
            }
            TrimQuery(1);
            return this;
        }

        /// <summary>
        /// Adds a Where statement to the current SQL query. This method takes a list of WhereClass instances as it's parameter.
        /// </summary>
        /// <param name="clauses">The WhereClass instances to add to this query.</param>
        /// <returns>This instance of QueryBuilder.</returns>
        public QueryBuilder Where(params WhereClass[] clauses)
        {
            query += " WHERE ";
            foreach(WhereClass wc in clauses)
            {
                query += wc;
            }
            if (query.EndsWith("AND"))
            {
                TrimQuery(3);
            }
            if (query.EndsWith("OR"))
            {
                TrimQuery(2);
            }
            return this;
        }

        /// <summary>
        /// A WhereClass for an SQL And statement. To be used in conjunction with a Where method.
        /// </summary>
        /// <returns>A WhereClass representing the SQL And statement.</returns>
        public WhereClass And()
        {
            return new WhereClass(" AND ");
        }

        public WhereClass IsBetweenDate(Column c, DateTime date1,DateTime date2)
        {
            string date1String = date1.ToString("yyyy-MM-dd");
            string date2String = date2.AddDays(1).ToString("yyyy-MM-dd");
            WhereClass d1WC = this.IsMoreThanEqual(c, date1String);
            WhereClass d2WC = this.IsLessThan(c, date2String);
            return new WhereClass(d1WC+" AND "+d2WC);
        }

        /// <summary>
        /// A WhereClass for an SQL Or statement. To be used in conjunction with a Where method.
        /// </summary>
        /// <returns>A WhereClass representing the SQL Or statement.</returns>
        public WhereClass Or()
        {
            return new WhereClass(" OR ");
        }

        /// <summary>
        /// A WhereClass for an SQL equals check. To be used in conjunction with a Where method.
        /// Takes a Column and an object.
        /// </summary>
        /// <param name="column1">The Column to be checked.</param>
        /// <param name="o">The object to be checked.</param>
        /// <returns>A WhereClass that represents the equality check in SQL.</returns>
        public WhereClass IsEqual(Column column1, object o)
        {
            WhereClass result;
            if(o is Column || o is int)
            {
                result = new WhereClass(column1 + " = " + o.ToString());
            }
            else
            {
                result = new WhereClass(column1 + " = '" + o.ToString()+"'");
            }
            return result;
        }

        /// <summary>
        /// A WhereClass for an SQL less than check. To be used in conjunction with a Where method.
        /// Takes a Column and an object.
        /// </summary>
        /// <param name="column1">The Column to be checked.</param>
        /// <param name="o">The object to be checked.</param>
        /// <returns>A WhereClass that represents the less than statement in SQL.</returns>
        public WhereClass IsLessThan(Column column1, object o)
        {
            WhereClass result;
            if (o is Column)
            {
                result = new WhereClass(column1 + " < " + o.ToString());
            }
            else
            {
                result = new WhereClass(column1 + " < '" + o.ToString() + "'");
            }
            return result;
        }
        public WhereClass IsLessThanEqual(Column column1, object o)
        {
            WhereClass result;
            if (o is Column)
            {
                result = new WhereClass(column1 + " <= " + o.ToString());
            }
            else
            {
                result = new WhereClass(column1 + " <= '" + o.ToString() + "'");
            }
            return result;
        }

        public WhereClass IsMoreThan(Column column1, object o)
        {
            WhereClass result;
            if (o is Column)
            {
                result = new WhereClass(column1 + " > " + o.ToString());
            }
            else
            {
                result = new WhereClass(column1 + " > '" + o.ToString() + "'");
            }
            return result;
        }
        public WhereClass IsMoreThanEqual(Column column1, object o)
        {
            WhereClass result;
            if (o is Column)
            {
                result = new WhereClass(column1 + " >= " + o.ToString());
            }
            else
            {
                result = new WhereClass(column1 + " >= '" + o.ToString() + "'");
            }
            return result;
        }

        /// <summary>
        /// Adds a semicolon to the finished query, and adds the query to the running list of queries performed.
        /// Checks to see if an Update statement is present without a Where statement, and throws an exception if so.
        /// </summary>
        /// <returns>A valid SQL query string.</returns>
        public override string ToString()
        {
            if (query.Contains("UPDATE") && !query.Contains("WHERE"))
            {
                throw new MalformedUpdateQueryException("You're trying to update a table without a 'where' clause, you will be break the entire table!");
            }
            query += ";";
            AddQuery(query);
            Console.WriteLine(query);
            return query;
        }

        public class WhereClass
        {
            private WhereClass() { }
            string result;
            public WhereClass(string result)
            {
                this.result = result;
            }

            public override string ToString()
            {
                return result;
            }
        }

        public class MalformedUpdateQueryException : Exception
        {
            public MalformedUpdateQueryException(string message) : base(message)
            {

            }
        }

        /// <summary>
        /// Dumps the stored queries that have been requested over the program lifetime,
        /// and how many times they have been requested.
        /// Outputs this information to standard output.
        /// </summary>
        public static void DumpLog()
        {
            foreach(KeyValuePair<string,int> kvp in pastQueries)
            {
                Console.WriteLine("[{0}] : {1}",kvp.Value,kvp.Key);
            }
        }
    }
}
