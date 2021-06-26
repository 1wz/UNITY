using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app2
{
    public partial class Form1 : Form
    {
        static Random ran = new Random();
        int s,h;
        public int ps;
        bool flag;
        public Form1()
        {
            InitializeComponent();
            s = ran.Next(1, 100);
            flag = false;
            h = 6;
        }

        //при нажатии на кнопку
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                label2.Text = "";
                label1.Text = "угадайте число от 1 до 100";
                button1.Text = "начать";
                s = ran.Next(1, 100);
                flag = false;
                h = 6;
            }
            else
            {
                button1.Text = "еще раз";
                Form2 form2 = new Form2();
                form2.ShowDialog();
                
                --h;
                label2.Text = $"осталось попыток: {h}";
                if (ps > s) label1.Text = "вы ввели слишком БОЛЬШОЕ число,\nпопробуйте еще раз";
                if (ps < s) label1.Text = "вы ввели слишком МАЛЕНЬКОЕ число,\nпопробуйте еще раз";
                if (ps == s)
                {
                    label1.Text = "ПРАВИЛЬНО";
                    button1.Text = "заново";
                    flag = true;
                }
                if (h == 0)
                {
                    label1.Text = "попытки кончились\nпопробуйте еще раз";
                    button1.Text = "заново";
                    flag = true;
                }
            }
        }
    }
}
