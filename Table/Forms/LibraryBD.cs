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

using Table.EventsLib;
using Table.Forms;

namespace Table
{
    public partial class LibraryBD : Form
    {
        //путь
        string path = null;

        public LibraryBD()
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

            
            try
            {
                XDocument xmlDoc = XDocument.Load(path);

                string sLast, sAuthor, sName, sPubl;
                int iCard, iReturn, iPrice, iYear;
                DateTime dIssue;

                sLast = Convert.ToString(textBox3.Text);
                sAuthor = Convert.ToString(textBox6.Text);
                sName = Convert.ToString(textBox7.Text);
                sPubl = Convert.ToString(textBox9.Text);

                iCard = Convert.ToInt32(textBox2.Text);
                iPrice = Convert.ToInt32(textBox10.Text);
                iYear = Convert.ToInt32(textBox8.Text);
                iReturn = Convert.ToInt32(textBox5.Text);

                dIssue = Convert.ToDateTime(textBox4.Text);


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
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(
                       "Файл не бл загружен",
                       "Ошибка",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error,
                       MessageBoxDefaultButton.Button1,
                       MessageBoxOptions.DefaultDesktopOnly);
            }
            catch 
            {
                MessageBox.Show(
                        "Введён неверный тип данных ",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                
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
            string[] s = new string[9];
            for (int i = 0; i < 9; i++)
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
            FilterProp setFilterForm = new FilterProp();
            setFilterForm.FilterChangeEvent += new EventHandler<FilterChangeEventArgs>(this.OnFilterChangeEvent);
            setFilterForm.Show();
        }

        public void OnFilterChangeEvent(object sender, FilterChangeEventArgs e)
        {
            //update this form, using information from e.Param
            //for example:
            //label10.Text = e.Param;

            //ЧТО ЛУЧШЕ ИСПОЛЬЗОВАТЬ? SWITCH или IF?????????????


            switch (e.radiobut)
            {
                case "author":
                case "publisher":
                case "library_card":
                    {
                        XElement xelement = XElement.Load(path);
                        var xes = from pub in xelement.Elements("record")
                                  where (string)pub.Element(e.radiobut) == e.Param
                                  select pub;

                        dataGridView1.Rows.Clear();

                        foreach (XElement elem in xes)
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



                            string[] r0 = { library_cardElement.Value, last_nameElement.Value, date_of_issueElement.Value,
                                    date_of_returnElement.Value, authorElement.Value, nameElement.Value, year_of_publicationElement.Value, publisher.Value,
                                    priceElement.Value};

                            dataGridView1.Rows.Add(r0);
                        }
                        break;
                    }
                case "date_of_issue":
                    {
                       XElement xelement = XElement.Load(path);

                        var xes = from pub in xelement.Elements("record")
                                  let dt = (DateTime)pub.Element("date_of_issue")
                                  let dtNow = DateTime.Now
                                  where dt.AddDays((double)pub.Element("date_of_return")) < dtNow
                                  select pub;
                        dataGridView1.Rows.Clear();

                        foreach (XElement elem in xes)
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



                            string[] r0 = { library_cardElement.Value, last_nameElement.Value, date_of_issueElement.Value,
                            date_of_returnElement.Value, authorElement.Value, nameElement.Value, year_of_publicationElement.Value, publisher.Value,
                            priceElement.Value};

                            dataGridView1.Rows.Add(r0);
                        }
                        break;

                       

                    }
            }
        }

        private void onClearClick(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        //Нумерация строк
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].HeaderCell.Value =
                (e.RowIndex + 1).ToString();
        }
    }


}
