using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Table
{
    public partial class Form1 : Form
    {
        //путь
        string path = null;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "Читательский билет";
            dataGridView1.Columns[1].Name = "Фамилия абонента";
            dataGridView1.Columns[2].Name = "Дата выдачи";
            dataGridView1.Columns[3].Name = "Дата возврата";
            dataGridView1.Columns[4].Name = "Автор";
            dataGridView1.Columns[5].Name = "Название";
            dataGridView1.Columns[6].Name = "Год издания";
            dataGridView1.Columns[7].Name = "Издательство";
            dataGridView1.Columns[8].Name = "Цена";
        }

        //кнопка Открыть файл XML
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".xml;";
            openFileDialog1.Filter = "XML файл (*.xml;)|*.xml;";
            openFileDialog1.Title = "Выберите XML документ";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                textBox1.Text = path;
                XDocument xdoc = XDocument.Load(path);
                ReadtoTableXML(xdoc);
                Console.WriteLine();
            }
        }

        //кнопка Записать
        private void button2_Click(object sender, EventArgs e)
        {


            XDocument xmlDoc = XDocument.Load(path);

            //если значения не пустые, записываем строчку
            if (textBox2.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "")
            {
                xmlDoc.Elements("catalog").First().Add(new XElement("record", new XElement("library_card", textBox2.Text), 
                                                                          new XElement("last_name", textBox3.Text), new XElement("date_of_issue", textBox4.Text), 
                                                                          new XElement("date_of_return", textBox5.Text), new XElement("author", textBox6.Text), 
                                                                          new XElement("name", textBox7.Text), new XElement("year_of_publication", textBox8.Text), 
                                                                          new XElement("publisher", textBox9.Text), new XElement("price", textBox10.Text)));

                xmlDoc.Save(path);
                string[] r0 = { textBox2.Text, textBox3.Text, textBox4.Text,
                                    textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text,
                                   textBox10.Text};
                dataGridView1.Rows.Add(r0);
                
            }
            else
            {
                MessageBox.Show(
                    "Введена пустая ячейка",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                return;
            }


            //очитска полей ввода
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

            //передаем фокус первому полю ввода
            textBox2.Focus();
        }
       



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ReadtoTableXML(XDocument xdoc)
        {


            foreach (XElement elem in xdoc.Element("catalog").Elements("record"))
            {
                XElement library_cardElement = elem.Element("library_card");
                XElement last_nameElement = elem.Element("last_name");
                XElement date_of_issueElement = elem.Element("date_of_issue");
                XElement date_of_returnElement = elem.Element("date_of_return");
                XElement authorElement = elem.Element("author");
                XElement nameElement = elem.Element("name");
                XElement year_of_publicationElement = elem.Element("year_of_publication");
                XElement publisher = elem.Element("publisher");
                XElement priceElement = elem.Element("price");


                try
                {
                    string[] r0 = { library_cardElement.Value, last_nameElement.Value, date_of_issueElement.Value,
                                    date_of_returnElement.Value, authorElement.Value, nameElement.Value, year_of_publicationElement.Value, publisher.Value,
                                    priceElement.Value};
                    dataGridView1.Rows.Add(r0);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show(
                        "Введена пустая ячейка",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Что-то пошло не так",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        //кнопка Удалить
        private void button3_Click(object sender, EventArgs e)
        {
            //записываем в массив выделенные ячейки
            string[] s=new string[9];
            for (int i=0; i<9; i++)
            {
                s[i] = (string)dataGridView1.CurrentRow.Cells[i].Value;
            }

            //удаляем выделенную строку из талицы
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }

            XDocument xmlDoc = XDocument.Load(path);

            //находим выделенные данные в xml файле
            var elementsToDelete = from ele in xmlDoc.Elements("catalog").Elements("record")
                                   where ele.Element("library_card").Value.Equals(s[0]) && ele.Element("last_name").Value.Equals(s[1]) &&
                                         ele.Element("date_of_issue").Value.Equals(s[2]) && ele.Element("date_of_return").Value.Equals(s[3]) &&
                                         ele.Element("author").Value.Equals(s[4]) && ele.Element("name").Value.Equals(s[5]) &&
                                         ele.Element("year_of_publication").Value.Equals(s[6]) && ele.Element("publisher").Value.Equals(s[7]) &&
                                         ele.Element("price").Value.Equals(s[8])
                                   select ele;

            //и удаляем их
            foreach (var el in elementsToDelete)
            {
                el.Remove();

            }

            xmlDoc.Save(path);

        }

        private void OnSetFilterClick(object sender, EventArgs e)
        {
            FilterProperties setFilterForm = new FilterProperties();
            setFilterForm.FilterChangeEvent += new EventHandler<FilterChangeEventArgs>(this.OnFilterChangeEvent);
            setFilterForm.Show();
        }

        public void OnFilterChangeEvent(object sender, FilterChangeEventArgs e)
        {
            //update this form, using information from e.Param
            //for example:
            tableView.Text += e.Param;
        }
    }
}
