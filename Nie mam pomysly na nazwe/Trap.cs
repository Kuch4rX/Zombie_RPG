using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nie_mam_pomysly_na_nazwe
{
    internal class Trap
    {
        public PictureBox trapLook;
        public bool activated;

        public Trap()
        {
        }

        public Trap(PictureBox trapLook, bool activated)
        {
            this.trapLook = trapLook;
            this.activated = activated;
        }
    }
}
