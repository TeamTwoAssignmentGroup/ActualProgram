using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mockup2.Tables;

namespace Mockup2
{
    class QueryBuilder
    {
        private string query = "";
        private static Dictionary<string, int> pastQueries = new Dictionary<string, int>();

        private void AddQuery(string q)
        {
            if (!pastQueries.ContainsKey(q))
            {
                pastQueries.Add(q, 0);
            }
            pastQueries[q]++;
        }

        public QueryBuilder Update(Table table)
        {
            query += "UPDATE " + table+" ";
            return this;
        }

        public QueryBuilder Insert(Table table)
        {
            query += "INSERT INTO " + table + " ";
            return this;
        }

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

        public QueryBuilder Set(params object[] o)
        {
            query += "SET ";
            for (int i = 0; i < o.Count(); i += 2)
            {
                object o1 = o[i];
                object o2 = o[i + 1];
                if(o2 is Tables.Column)
                {
                    query += o1 + " = " + o2;
                }
                else
                {
                    query += o1 + " = '" + o2 + "', ";
                }
            }
            TrimQuery(2);
            return this;
        }

        public QueryBuilder Select(params Column[] columns)
        {
            query += "SELECT ";
            foreach(Mockup2.Tables.Column c in columns)
            {
                query += c+",";
            }
            TrimQuery(1);
            return this;
        }

        public void TrimQuery(int amount)
        {
            query = query.Remove(query.Length - amount);
        }

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

        public WhereClass And()
        {
            return new WhereClass(" AND ");
        }

        public WhereClass Or()
        {
            return new WhereClass(" OR ");
        }

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

        public override string ToString()
        {
            if (query.Contains("UPDATE") && !query.Contains("WHERE"))
            {
                throw new MalformedUpdateQueryException("You're trying to update a table without a 'where' clause, you will be break the entire table!");
            }
            query += ";";
            AddQuery(query);
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

        public static void DumpLog()
        {
            foreach(KeyValuePair<string,int> kvp in pastQueries)
            {
                Console.WriteLine("[{0}] : {1}",kvp.Value,kvp.Key);
            }
        }
    }
}
