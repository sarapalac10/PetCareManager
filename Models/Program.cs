using System;
using System.Windows.Forms;

namespace PetCareInterface
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Esta línea es la que lanza tu ventana
            Application.Run(new Form1());
        }
    }
} 