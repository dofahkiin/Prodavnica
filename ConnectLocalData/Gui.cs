using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectLocalData
{
    public partial class Gui : Form
    {
        public Gui()
        {
            InitializeComponent();
        }

        private void artikliBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.artikliBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sampleDatabaseDataSet);

        }

        private void Gui_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sampleDatabaseDataSet.Artikli' table. You can move, or remove it, as needed.
            this.artikliTableAdapter.Fill(this.sampleDatabaseDataSet.Artikli);

        }

        private void fillByArtikal1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.artikliTableAdapter.FillByArtikal1(this.sampleDatabaseDataSet.Artikli, artikalToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void resetToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.artikliTableAdapter.Reset(this.sampleDatabaseDataSet.Artikli);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program razvili:\nMiloš Mandarić i Vladimir Budinčić", "O programu");
        }
  
    }
}
