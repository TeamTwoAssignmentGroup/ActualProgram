using Mockup2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mockup2.DatabaseClasses.Tables;

namespace Mockup2.DatabaseClasses
{
    /// <summary>
    /// A helper class to better encapsulate data returned from the database when using the <see cref="CustomTableFactory"/> class.
    /// Probably a bit superfluous, but may become more useful as time goes on.
    /// </summary>
    public class CustomTable
    {
        private List<Dictionary<Column,object>> columnData;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnData">The data that makes up this table.</param>
        public CustomTable(List<Dictionary<Column, object>> columnData)
        {
            this.columnData = columnData;
        }

        /// <summary>
        /// Gets the underling data that makes up this table.
        /// </summary>
        /// <returns>A <see cref="List{Dictionary}"/> that represents the underlying database data. Each <see cref="Dictionary{Column, Object}"/> is considered a row.</returns>
        public List<Dictionary<Column,object>> GetRows()
        {
            return columnData;
        }

        /// <summary>
        /// Converts to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";
            foreach(var row in columnData)
            {
                foreach(object o in row.Values)
                {
                    result += o + " | ";
                }
                result += System.Environment.NewLine;
            }
            return result;
        }
    }
}
