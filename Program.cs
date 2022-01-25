using System;
using System.Windows.Forms;
using System.Drawing;

namespace wordle_solver
{
    public class Program
    {
        public static Form1 form = new Form1();
        [STAThread]
        static void Main()
        {
            form.FormLayout();
            Application.Run(form);
        }
    }
}