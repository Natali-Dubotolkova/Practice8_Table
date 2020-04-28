using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_reader
{
    class Program
    {
        static void Main()
        {
            var reader = new XmlTextReader("pr8.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // Проверка на тип узла необходима, иначе будут найдены не только открывающие элементы (XmlNodeType.Element),
                    // но и закрывающие (XmlNodeType.EndElement).
                    if (reader.Name.Equals("Title"))   // Закомментировать и выполнить.
                    {
                        Console.WriteLine("<{0}>", reader.GetAttribute("FontSize"));
                    }
                }
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
