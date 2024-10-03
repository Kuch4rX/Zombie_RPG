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
        public bool Stunned;
        public bool StunnedByWeapon;

        public Enemy(Timer cooldown, int hP, PictureBox enemyLook, bool enemyCooldown, int speed, bool stunned, bool stunnedbyweapon)
        {
            Cooldown = cooldown;
            HP = hP;
            EnemyLook = enemyLook;
            EnemyCooldown = enemyCooldown;
            Speed = speed;
            Stunned = stunned;
            StunnedByWeapon = stunnedbyweapon;
        }
    }
}
