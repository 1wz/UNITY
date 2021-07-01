using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.ListBox;

namespace Languege
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// при запуске программы подгружает слова из файла xml
        /// </summary>
        public Form1()
        {
            List<word> list;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<word>));
            using (Stream stream = new FileStream("XMLFile1.xml", FileMode.Open, FileAccess.Read))
            {
                list= (List<word>)xmlSerializer.Deserialize(stream);
            }
            InitializeComponent();
            foreach(word w in list)
            {
                listBox1.Items.Add(w);
            }
        }

        /// <summary>
        /// при выходе из программы сохраняет слова в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<word> list=new List<word>();
            foreach(word w in listBox1.Items)
            {
                list.Add(w);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(list.GetType());
            using (Stream stream = new FileStream("XMLFile1.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, list);
            }
        }

        //кнопочка "добавить"
        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        //кнопочка "отмена"
        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        //при нажатии на ОК слово добавляется в список
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
                listBox1.Items.Add(new word(textBox1.Text, textBox2.Text));
            button4_Click(new object(), new EventArgs());
            //MessageBox.Show(textBox1.Text);
        }

        //при нажатии УДАЛИТЬ удаляет выбранное слово
        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex>=0)
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
