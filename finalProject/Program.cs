using System;
using System.Collections.Generic;
using System.Linq;
//@ALSHLKANY
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalProject
{
    static class Program
    {
        /// <ALSHLKANY>
        /// The main entry point for the application.
        /// </ALSHLKANY>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
}
