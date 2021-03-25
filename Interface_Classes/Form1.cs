using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface_Classes
{
    public partial class Form1 : Form
    {
        Items item1;

        interface IItems
        {
            public void GetInfo(ListBox lb1)
            {
                lb1.Items.Add("Наименование товара: " + title);
                lb1.Items.Add("Остаток товара: " + count.ToString());
                lb1.Items.Add("Цена товара: " + price.ToString());
            }

            public void SellItem(int count_for_sell)
            {
                if (count >= count_for_sell)
                {
                    count -= count_for_sell;
                }
                else
                {
                    MessageBox.Show("Запрошенного количества товара нет на складе. Продажа невозможна.");
                }
            }


        }

        class Items : IItems
        {
            public string title;
            public int count;
            public int price;

            public Items(string t, int c, int p)
            {
                title = t;
                count = c;
                price = p;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            item1.GetInfo(listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            item1 = new Items(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            button1.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            item1.SellItem(Convert.ToInt32(textBox4.Text));
        }
    }
}
}
