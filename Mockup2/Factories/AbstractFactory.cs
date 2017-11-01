using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.Factories
{
    abstract class AbstractFactory
    {
        internal DBConnection dbCon;
        public AbstractFactory(DBConnection dbCon)
        {
            this.dbCon = dbCon;
        }

        internal int GetInt(object o)
        {
            return int.Parse(o + "");
        }

        internal string GetString(object o)
        {
            return o + "";
        }

        internal bool GetBool(object o)
        {
            if(o is int)
            {
                return Convert.ToInt32(o) > 0;
            }
            if(o is string)
            {
                switch (o.ToString())
                {
                    case "1": return true;
                    case "0": return false;
                }
            }
            return bool.Parse(o.ToString());
        }

        internal DateTime GetDateTime(object o)
        {
            DateTime result;
            DateTime.TryParse(o.ToString(),out result);
            return result;
        }
    }
}
