using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nie_mam_pomysly_na_nazwe
{
    internal class Enemy
    {
        public Timer Cooldown;
        public int HP;
        public PictureBox EnemyLook;
        public bool EnemyCooldown;
        public int Speed;

        public Enemy(Timer cooldown, int hP, PictureBox enemyLook, bool enemyCooldown, int speed)
        {
            Cooldown = cooldown;
            HP = hP;
            EnemyLook = enemyLook;
            EnemyCooldown = enemyCooldown;
            Speed = speed;
        }
    }
}
