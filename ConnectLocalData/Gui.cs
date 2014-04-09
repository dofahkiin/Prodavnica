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

            updateTableRows();



        }

        void updateTableRows()
        {
            toolStripStatusLabel1.Text = string.Format("Broj artikala: {0}", artikliDataGridView.RowCount);
        }

        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(Object sender, EventArgs e)
        {

            if(tabControl1.SelectedIndex == 1)
            {
                toolStripStatusLabel1.Text = "Unos artikla:";
            }

            else
            {
                updateTableRows();
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

            updateTableRows();

            
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
               if (textBox1.Text.Length == 0)
               {
                   this.panel1.BackColor = System.Drawing.Color.Red;
                   this.label6.Visible = true;
               }
               else
               {
                   this.panel1.BackColor = System.Drawing.Color.White;
                   this.label6.Visible = false;
               }

               if (textBox2.Text.Length == 0)
               {
                   this.panel2.BackColor = System.Drawing.Color.Red;
                   this.label7.Visible = true;
               }
               else
               {
                   this.panel2.BackColor = System.Drawing.Color.White;
                   this.label7.Visible = false;
               }

               if (textBox3.Text.Length == 0)
               {
                   this.panel3.BackColor = System.Drawing.Color.Red;
                   this.label8.Visible = true;
               }
               else
               {
                   this.panel3.BackColor = System.Drawing.Color.White;
                   this.label8.Visible = false;
               }

               if (textBox4.Text.Length == 0)
               {
                   this.panel4.BackColor = System.Drawing.Color.Red;
                   this.label9.Visible = true;
               }
               else
               {
                   this.panel4.BackColor = System.Drawing.Color.White;
                   this.label9.Visible = false;
               }

               if (textBox5.Text.Length == 0)
               {
                   this.panel5.BackColor = System.Drawing.Color.Red;
                   this.label10.Visible = true;
               }
               else
               {
                   this.panel5.BackColor = System.Drawing.Color.White;
                   this.label10.Visible = false;
               }

               toolStripStatusLabel1.Text = "Unos artikla: niste unijeli sva polja!";

            }

            else
            {
                Single cijena = 0;
                try
                {
                    try
                    {
                        cijena = Convert.ToSingle(textBox5.Text);

                        this.artikliTableAdapter.Insert(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt16(textBox4.Text), cijena);

                        this.artikliTableAdapter.Reset(this.sampleDatabaseDataSet.Artikli);

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();

                        toolStripStatusLabel1.Text = "Unos artikla: artikal unijet!";

                        this.panel1.BackColor = System.Drawing.Color.White;
                        this.panel2.BackColor = System.Drawing.Color.White;
                        this.panel3.BackColor = System.Drawing.Color.White;
                        this.panel4.BackColor = System.Drawing.Color.White;
                        this.panel5.BackColor = System.Drawing.Color.White;
                        this.label6.Visible = false;
                        this.label7.Visible = false;
                        this.label8.Visible = false;
                        this.label9.Visible = false;
                        this.label10.Visible = false;
                    }
                    catch(System.FormatException)
                    {
                        MessageBox.Show("Nepravilno ste unijeli cijenu, molimo pokušajte ponovo.");
                    }


                   
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Unijeli ste već postojeću šifru, molimo pokušajte ponovo.");
                }
                
               
            }
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
