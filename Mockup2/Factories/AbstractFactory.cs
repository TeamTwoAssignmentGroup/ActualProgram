using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.Factories
{
    /// <summary>
    /// An astract factory class for othe table factories to inherit from. Provides
    /// some convenience methods for parsing data from the database.
    /// </summary>
    public abstract class AbstractFactory
    {
        internal DBConnection dbCon;
        public AbstractFactory(DBConnection dbCon)
        {
            this.dbCon = dbCon;
        }

        /// <summary>
        /// Parses the given object as an int.
        /// </summary>
        /// <param name="o">Object to parse.</param>
        /// <returns>An int from the object.</returns>
        internal int GetInt(object o)
        {
            return int.Parse(o + "");
        }

        /// <summary>
        /// Converts the given object to a string. Simply calls
        /// <code>o.ToString()</code>
        /// </summary>
        /// <param name="o">The object to parse.</param>
        /// <returns>A string from the object.</returns>
        internal string GetString(object o)
        {
            return o.ToString();
        }

        /// <summary>
        /// Parses the object as a boolean.
        /// </summary>
        /// <param name="o">The object to parse.</param>
        /// <returns>A boolean representation of the object.</returns>
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
                    case "True":return true;
                    case "False":return false;
                }
            }
            return bool.Parse(o.ToString());
        }

        /// <summary>
        /// Parses the object as a DateTime object.
        /// </summary>
        /// <param name="o">The object to parse.</param>
        /// <returns>A DateTime representation of the object, if possible.</returns>
        internal DateTime GetDateTime(object o)
        {
            DateTime result;
            DateTime.TryParse(o.ToString(),out result);
            return result;
        }
    }
}
