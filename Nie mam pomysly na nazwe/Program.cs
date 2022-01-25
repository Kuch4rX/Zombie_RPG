using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nie_mam_pomysly_na_nazwe
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();*/
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RPG_Kapek());
        }
    }
}
