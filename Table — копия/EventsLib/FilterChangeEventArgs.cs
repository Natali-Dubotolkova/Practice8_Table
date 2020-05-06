using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table.EventsLib
{
    public class FilterChangeEventArgs : EventArgs
    {
        public string Param { get; internal set; }

        public FilterChangeEventArgs(string paramValue)
        {
            Param = paramValue;
        }
    }
}
