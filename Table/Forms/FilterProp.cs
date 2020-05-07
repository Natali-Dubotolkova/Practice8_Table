using System;
using System.Windows.Forms;

using Table.EventsLib;

namespace Table.Forms
{
    public partial class FilterProp : Form
    {
        public event EventHandler<FilterChangeEventArgs> FilterChangeEvent;
        public string radiobuttonValue;
        public FilterProp()
        {
            InitializeComponent();
        }

        private void OnBtnApplyClick(object sender, EventArgs e)
        {
            EventHandler<FilterChangeEventArgs> handler = FilterChangeEvent;
            handler?.Invoke(this, new FilterChangeEventArgs(paramTxtBox.Text, radiobuttonValue));
            Close();
        }

        private void FilterProperties_Load(object sender, EventArgs e)
        {

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            // приводим отправителя к элементу типа RadioButton
            RadioButton radioButton = (RadioButton)sender;
            
            if (radioButton.Checked)
            {
                switch (radioButton.Text)
                {
                    case "Издательство":
                        MessageBox.Show("Введите в текстовое поле название издательства");
                        radiobuttonValue = "publisher";
                        break;
                    case "Автор":
                        MessageBox.Show("Введите в текстовое поле ФИО автора");
                        radiobuttonValue = "author";
                        break;
                    case "Читательский билет":
                        MessageBox.Show("Введите в текстовое поле номер читательского билета");
                        radiobuttonValue = "library_card";
                        break;
                    case "Просроченные":
                        MessageBox.Show("Нажимайте на кнопку, вводить ничего не нужно");
                        radiobuttonValue = "date_of_issue";
                        break;
                    default:
                        MessageBox.Show("Что-то пошло не так");
                        break;
                }
            }
            //else MessageBox.Show("Вы ничего не выбрали");
        }
    }
}
