using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ntp3_2o_20170413_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        object[] s;
        ArrayList cekilis;
        Random r = new Random(5);

        private void button1_Click(object sender, EventArgs e)
        {
            altiliOynat();
            dataGridView1.Rows.Add(s);
            dataGridView1.Rows[dataGridView1.Rows.Count - 2].HeaderCell.Value =
                (dataGridView1.Rows.Count - 1).ToString();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {//çekiliş yap
            
            listBox1.Items.Clear();
            altiliOynat();
            listBox1.Items.AddRange(s);
            for (int i = 0; i < listBox1.Items.Count; i++)
                listBox1.Items[i] = (i + 1).ToString() + ". sayı: " + listBox1.Items[i];
            cekilis = new ArrayList(s);
            //cekilis.AddRange(s);

            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                foreach (DataGridViewCell itemi in rw.Cells)
                {
                    itemi.Style.BackColor = Color.White;
                }
            }

        }
        private void altiliOynat()
        {
            s = new object[6];
            
            int x;
            bool varmi;
            for (int i = 0; i < 6; i++)
            {
                do
                {
                    x = r.Next(1, 50);
                    varmi = false;
                    for (int j = 0; j < i; j++)
                        if (Convert.ToInt32(s[j]) == x)
                        { varmi = true; break; }
                } while (varmi == true);

                s[i] = x;
            }
            Array.Sort(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int say;
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                say = 0;
                for (int si = 0; si < 6; si++)
                {
                    int x = cekilis.IndexOf(dataGridView1.Rows[i].Cells[si].Value);
                    if (x > -1)
                    {
                        say++;
                        dataGridView1.Rows[i].Cells[si].Style.BackColor =
                            Color.Red;
                    }
                }
                dataGridView1.Rows[i].Cells[6].Value = say.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                button1_Click(null, null);
            }
        }


    }
}
