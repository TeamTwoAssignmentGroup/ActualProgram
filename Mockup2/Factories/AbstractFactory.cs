using Mockup2.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.Factories
{
    /// <summary>
    /// An astract factory class for other table factories to inherit from. Provides
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
        /// Parses the given <see cref="object"/> as an <see cref="int"/>.
        /// </summary>
        /// <param name="o"><see cref="object"/> to parse.</param>
        /// <returns>An <see cref="int"/> from the <see cref="object"/>.</returns>
        internal int GetInt(object o)
        {
            return int.Parse(o + "");
        }

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/>. Simply calls
        /// <code>o.ToString()</code>
        /// </summary>
        /// <param name="o">The <see cref="object"/> to parse.</param>
        /// <returns>A <see cref="string"/> from the object.</returns>
        internal string GetString(object o)
        {
            return o.ToString();
        }

        /// <summary>
        /// Parses the <see cref="object"/> as a <see cref="bool"/>.
        /// </summary>
        /// <param name="o">The <see cref="object"/> to parse.</param>
        /// <returns>A <see cref="bool"/> representation of the <see cref="object"/>.</returns>
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
        /// Parses the <see cref="object"/> as a <see cref="DateTime"/> object.
        /// </summary>
        /// <param name="o">The <see cref="object"/> to parse.</param>
        /// <returns>A <see cref="DateTime"/> representation of the <see cref="object"/>, if possible.</returns>
        internal DateTime GetDateTime(object o)
        {
            DateTime result;
            DateTime.TryParse(o.ToString(),out result);
            return result;
        }
    }
}
