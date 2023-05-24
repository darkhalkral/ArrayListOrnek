using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace ders9._4
{
    public partial class Form1 : Form
    {
        ArrayList eleman = new ArrayList();
        Boolean deger;
        int kolon;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Kimlik", 50);
            listView1.Columns.Add("Ad", 70);
            listView1.Columns.Add("Soyad", 70);
            kolon = listView1.Columns.Count - 1;
        }

        void listele()
        {
            int kolon2;
            listView1.Items.Clear();
            int sonsira = 0;
            kolon2 = eleman.Count / kolon;
            for (int i = 1; i <= kolon2; i++)
            {
                listView1.Items.Add(i.ToString());
            }

            for (int i = 0; i < kolon2; i++)
            {
                int sinir = 0;
                for (int k = sonsira; k < eleman.Count; k++)
                {
                    sonsira = k;
                    sinir++;
                    if (sinir == listView1.Columns.Count)
                        break;
                    listView1.Items[i].SubItems.Add(eleman[k].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Önce Ad ve Soyad Bilgilerini Giriniz");
            }
            else
            {
                for (int i = 0; i < eleman.Count; i = i + kolon)
                {
                    if (textBox1.Text == eleman[i].ToString() && textBox2.Text == eleman[i + 1].ToString())
                    {
                        deger = true;
                    }
                }
                if (deger)
                {
                    MessageBox.Show("Bu Kişi Daha Önce Girilmiş", "Uyarı");
                }
                else
                {
                    eleman.Add(textBox1.Text);
                    eleman.Add(textBox2.Text);

                    textBox1.Clear();
                    textBox2.Clear();

                    listele();
                }

                deger = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Önce Ad, Soyad ve Eklenilecek Sıra Bilgilerini Giriniz");
            }
            else
            {
                for (int i = 0; i < eleman.Count; i = i + kolon)
                {
                    if (textBox1.Text == eleman[i].ToString() && textBox2.Text == eleman[i + 1].ToString())
                    {
                        deger = true;
                    }
                }
                if (deger)
                {
                    MessageBox.Show("Bu Kişi Daha Önce Girilmiş", "Uyarı");
                }
                else
                {
                    if (int.Parse(textBox3.Text) <= (eleman.Count / kolon) + 1)
                    {
                        eleman.Insert(((int.Parse(textBox3.Text)) * kolon) - kolon, textBox1.Text);
                        eleman.Insert(((int.Parse(textBox3.Text)) * kolon) - (kolon - 1), textBox2.Text);

                        textBox1.Clear();
                        textBox2.Clear();

                        listele();
                    }
                    else
                    {
                        MessageBox.Show("Önce " + ((eleman.Count / kolon) + 1).ToString() + " Satırına Veri Giriniz");
                    }

                }
                deger = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox4.Text == "")
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Seçili veya Girilen değer yok", "Uyarı");
                }
                else
                {
                    for (int i = 0; i < listView1.SelectedItems.Count; i++)
                    {
                        int sayi = listView1.SelectedItems[0].Index + 1;

                        eleman.RemoveAt((sayi * kolon) - kolon);
                        eleman.RemoveAt((sayi * kolon) - kolon);
                    }
                    listele();
                }


            }
            else
            {
                int sayi = int.Parse(textBox4.Text);
                if (sayi <= (eleman.Count / kolon))
                {
                    eleman.RemoveAt((sayi * kolon) - kolon);
                    eleman.RemoveAt((sayi * kolon) - kolon);

                    listele();
                }
                else
                {
                    MessageBox.Show("Girilen Satırda Veri Yok", "Uyarı");
                }

            }
        }
    }
}



