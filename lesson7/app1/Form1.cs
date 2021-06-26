using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app1
{
    public partial class Form1 : Form
    {
        static Random ran = new Random();
        int h,hh,s;
        Stack<int> numbers = new Stack<int>();

        public Form1()
        {
           
            InitializeComponent();
            button4_Click(new object(), new EventArgs());
        }

        //нажатие на кнопку "+1"
        private void button2_Click(object sender, EventArgs e)
        {
            numbers.Push(int.Parse(label1.Text));
            label1.Text = (int.Parse(label1.Text) + 1).ToString();
            ++h;
            hod();
        }

        //кнопка *2
        private void button3_Click(object sender, EventArgs e)
        {
            numbers.Push(int.Parse(label1.Text));
            label1.Text = (int.Parse(label1.Text) * 2).ToString();
            ++h;
            hod();
        }

        //кнопочка сброс, начинает игру с начала
        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "1";
            hh = 0;
            h = 0;
            s = ran.Next(8, 20);
            label4.Text = s.ToString();
            int ss = s;
            while (ss != 1)
            {
                if (ss % 2 == 0) ss /= 2;
                else --ss;
                ++hh;
            }
            numbers.Clear();
            hod();
        }

        //проверки после каждого хода
        private void hod()
        {
            
            label3.Text = $"осталось ходов: {hh-h}";
            if(s== int.Parse(label1.Text))
            {
                MessageBox.Show("Победа!");
                button4_Click(new object(), new EventArgs());
                return;
            }
            if (s < int.Parse(label1.Text))
            {
                MessageBox.Show("Слишком много!");
                button6_Click(new object(), new EventArgs());
                return;
            }
            if(hh-h==0)
            {
                button2.Enabled = false;
                button3.Enabled = false;
                MessageBox.Show("Кончились ходы!");
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
            if (numbers.Count == 0) button6.Enabled = false;
            else button6.Enabled = true;

        }

        //кнопочка сброс
        private void button6_Click(object sender, EventArgs e)
        {
            --h;
            label1.Text = numbers.Pop().ToString();
            hod();
        }

        //скрывает меню после нажатия "игра"
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        //закрывает просграмму после нажатия "выход"
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
