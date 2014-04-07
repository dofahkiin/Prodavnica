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


        private void Gui_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sampleDatabaseDataSet.Artikli' table. You can move, or remove it, as needed.
            this.artikliTableAdapter.Fill(this.sampleDatabaseDataSet.Artikli);

            MyItem[] list = new MyItem[3];
            list[0] = new MyItem("Artikal", 1);
            list[1] = new MyItem("Vrsta", 2);
            list[2] = new MyItem("Šifra", 3);

            toolStripComboBox1.Items.AddRange(list);
            toolStripComboBox1.SelectedIndex = 0;

        }

        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }
        }


        private void fillByArtikal1ToolStripButton_Click(object sender, EventArgs e)
        {

            search();
          

        }

        public void search()
        {
            // Ako je prezan textbox, prikaži sve artikle
            if (artikalToolStripTextBox.Text.Length == 0)
            {
                reset();
            }

            else
            {
                int index = toolStripComboBox1.SelectedIndex;


                if (index == -1 || index == 0)
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

                else if (index == 1)
                {



                    try
                    {
                        this.artikliTableAdapter.FillByVrsta(this.sampleDatabaseDataSet.Artikli, artikalToolStripTextBox.Text);
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }


                }

                else if (index == 2)
                {
                    try
                    {
                        this.artikliTableAdapter.FillBySifra(this.sampleDatabaseDataSet.Artikli, artikalToolStripTextBox.Text);
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }

                }
            }

            
        }

        public void reset()
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

        private void resetToolStripButton_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program razvili:\nMiloš Mandarić i Vladimir Budinčić", "O programu");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.artikliTableAdapter.Insert("Test", "Test", "9999", 2, 90);

            if( textBox1.Text.Length == 0 ||
                textBox2.Text.Length == 0 ||
                textBox3.Text.Length == 0 ||
                textBox4.Text.Length == 0 ||
                textBox5.Text.Length == 0)
            {
                MessageBox.Show("Niste unijeli sve potrebne podatke!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                this.artikliTableAdapter.Insert(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt16(textBox4.Text), Convert.ToSingle(textBox5.Text));
                this.artikliTableAdapter.Reset(this.sampleDatabaseDataSet.Artikli);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }

            
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

  
    }

    public class MyItem
    {
        public string String { get; set; }
        public int Int { get; set; }
        public MyItem(string s, int i) { String = s; Int = i; }
        public override string ToString()
        {
            return String;
        }
    }
}
