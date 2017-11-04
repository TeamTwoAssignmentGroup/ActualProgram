using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mockup2.Tables;

namespace Mockup2
{
    /// <summary>
    /// An object representation of a temporary table containing a result set from an SQL
    /// query. 
    /// </summary>
    class CustomTable
    {
        private List<Dictionary<Column,object>> columnData;
        public CustomTable(List<Dictionary<Column, object>> columnData)
        {
            this.columnData = columnData;
        }

        public List<Dictionary<Column,object>> GetRows()
        {
            return columnData;
        }
    }
}
