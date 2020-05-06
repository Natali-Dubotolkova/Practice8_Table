using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Read_Write
{
    /// <summary>
    /// Каталог телефонных номеров.
    /// </summary>
    public class Catalog
    {
        /// <summary>
        /// Список телефонных номеров.
        /// </summary>
        public List<Phone> Phones { get; set; } = new List<Phone>();
    }
}
