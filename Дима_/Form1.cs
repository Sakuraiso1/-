using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Дима_
{
    public partial class Form1 : Form
    {
        public string MyValue
        {
            get { return dataGridView2.RowCount.ToString(); }
        }
        public static int a = 3;
        public const int INF = 99999;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            dataGridView1.RowCount = a;
            dataGridView1.ColumnCount = a;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    if (i == j)
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                        dataGridView1.Rows[i].Cells[j].Value = 0;
                    }
                }
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = i.ToString();
                dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox2.Text);
            dataGridView1.RowCount += n;
            dataGridView1.ColumnCount += n;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    if (i == j)
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                        dataGridView1.Rows[i].Cells[j].Value = 0;
                    }
                }
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = i.ToString();
                dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (i > j) { dataGridView1.Rows[i].Cells[j].Value = rand.Next(0, 20); }

                }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (j > i) { dataGridView1.Rows[i].Cells[j].Value = dataGridView1.Rows[j].Cells[i].Value; }
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.RowCount = dataGridView1.Rows.Count;
            dataGridView2.ColumnCount = dataGridView1.Rows.Count;
            int[,] distance = new int[dataGridView1.Rows.Count, dataGridView1.Rows.Count];
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                for (int j = 0; j < dataGridView1.Rows.Count; ++j)
                    distance[i, j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
            for (int k = 0; k < dataGridView1.Rows.Count; ++k)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count; ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                            distance[i, j] = distance[i, k] + distance[k, j];
                    }
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; ++j) 
                {
                    dataGridView2.Rows[i].Cells[j].Value = distance[i, j];
                    dataGridView2.Rows[i].Cells[j].ReadOnly = true;
                    dataGridView2.Columns[i].HeaderText = i.ToString();
                    dataGridView2.Rows[i].HeaderCell.Value = i.ToString();
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int[] array = new int[dataGridView1.Rows.Count];
            dataGridView2.RowCount = dataGridView1.Rows.Count;
            dataGridView2.ColumnCount = dataGridView1.Rows.Count;
            int[,] distance = new int[dataGridView1.Rows.Count, dataGridView1.Rows.Count];
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                for (int j = 0; j < dataGridView1.Rows.Count; ++j)
                    distance[i, j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
            for (int k = 0; k < dataGridView1.Rows.Count; ++k)
            {
                for (int i = a; i < dataGridView1.Rows.Count; ++i)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count; ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                            distance[i, j] = distance[i, k] + distance[k, j];
                    }
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; ++j)
                {
                    dataGridView2.Rows[i].Cells[j].Value = distance[i, j];
                    dataGridView2.Rows[i].Cells[j].ReadOnly = true;
                    dataGridView2.Columns[i].HeaderText = i.ToString();
                    dataGridView2.Rows[i].HeaderCell.Value = i.ToString();
                }
            }
        }

    }
}
