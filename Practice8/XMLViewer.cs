using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using XMLGUI.Forms;
using XMLGUI.EventsLib;

namespace XMLGUI
{
    public partial class XMLViewer : Form
    {
        public XMLViewer()
        {
            InitializeComponen();
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

        private void InitializeComponents()
        {
            this.SuspendLayout();
            // 
            // XMLViewer
            // 
            this.ClientSize = new System.Drawing.Size(329, 253);
            this.Name = "XMLViewer";
            this.ResumeLayout(false);

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // XMLViewer
            // 
            this.ClientSize = new System.Drawing.Size(507, 333);
            this.Name = "XMLViewer";
            this.Load += new System.EventHandler(this.XMLViewer_Load);
            this.ResumeLayout(false);

        }

        private void XMLViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
