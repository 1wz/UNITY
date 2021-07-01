using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrueFalseEditor
{
    public partial class Form1 : Form
    {

        private List<Question> list;
        int num;//переменная для автосохранения вопросов
        string fileName;

        public Form1()
        {
            InitializeComponent();
            menuItemNew_Click(new object(), new EventArgs());
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
                list = new List<Question>();
                list.Add(new Question("Введите сюда вопрос", true));
                fileName = null;
                visual(0);
                num = 1;
                nudNumber.Maximum = 1;
                nudNumber.Minimum = 1;
                nudNumber.Value = 1;
                SetDel();
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                list = JWL.Load(openFileDialog.FileName);
                fileName = openFileDialog.FileName;
                visual(0);
                num = 1;
                nudNumber.Maximum = list.Count;
                nudNumber.Minimum = 1;
                nudNumber.Value = 1;
                SetDel();
            }
        }

        /// <summary>
        /// если файл уже сохраняли, сохраняет в ту же директорию, иначе предлагает выбрать новую директорию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            try
            {
                JWL.Save(fileName, list);
            }
            catch(System.IO.FileNotFoundException)
            {
                сохранитьКакToolStripMenuItem_Click(new object(), new EventArgs());
            }
            catch(System.ArgumentNullException)
            {
                сохранитьКакToolStripMenuItem_Click(new object(), new EventArgs());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            list.Add(new Question("Введите сюда вопрос", true));
            nudNumber.Maximum = list.Count;
            nudNumber.Value = list.Count;
            SetDel();
        }

        /// <summary>
        /// при смене вопроса сохраняет предыдущий и отображает новый
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            list[num - 1].Text = tbQuestion.Text;
            list[num - 1].TrueFalse = cbTrue.Checked;
            num = (int)nudNumber.Value;
            visual((int)nudNumber.Value - 1);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            int n = (int)nudNumber.Value - 1;//сохраняет индекс удаляемого вопроса,на случай если он изменится в следующей строке
            nudNumber.Maximum = nudNumber.Maximum - 1;
            list.RemoveAt(n);
            visual((int)nudNumber.Value - 1);
            SetDel();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog = new SaveFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                JWL.Save(openFileDialog.FileName,list);
                fileName= openFileDialog.FileName;
            }
        }

        /// <summary>
        /// отображает i-ый вопрос
        /// </summary>
        private void visual(int i)
        {
            tbQuestion.Text = list[i].Text;
            cbTrue.Checked = list[i].TrueFalse;
            this.label1.Text = list.Count.ToString();
        }

        /// <summary>
        /// выключает кнопку "удалить"
        /// </summary>
        private void SetDel()
        {
            if (list.Count == 1) btnDelete.Enabled = false;
            else btnDelete.Enabled = true;
        }
    }
}
