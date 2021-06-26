// Требуется добавить в проект ссылки на сборки System.Drawing и System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
class MyProgram
{
    public static void Main()
    {
        Application.Run(new MyForm());
    }
}

class MyForm : Form
{
    public MyForm()
    {
        Text = "My Inherited Form";
        Width *= 2;
        Click += MyClicker;
        Paint += MyPainter;
    }
    void MyClicker(object objSrc, EventArgs args)
    {
        MessageBox.Show("The button has been clicked!", "Click");
    }
    void MyPainter(object objSrc, PaintEventArgs args)
    {
        Graphics grfx = args.Graphics;
        grfx.DrawString("Hello, Windows Forms", Font,
        SystemBrushes.ControlText, 0, 0);
    }
}
