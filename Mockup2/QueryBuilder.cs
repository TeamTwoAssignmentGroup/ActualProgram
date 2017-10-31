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

        public QueryBuilder Select(params Column[] columns)
        {
            query += "SELECT ";
            foreach(Column c in columns)
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
            if(o is Column)
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

        public override string ToString()
        {
            return query+";";
        }

        public class WhereClass
        {
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
    }
}
