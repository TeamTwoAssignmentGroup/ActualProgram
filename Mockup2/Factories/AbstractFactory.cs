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

        internal DateTime GetDateTime(object o)
        {
            DateTime result;
            DateTime.TryParse(o.ToString(),out result);
            return result;
        }
    }
}
