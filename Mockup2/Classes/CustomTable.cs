using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mockup2.Tables;

namespace Mockup2
{



    /// <summary>
    /// OUT OF ORDER 
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
