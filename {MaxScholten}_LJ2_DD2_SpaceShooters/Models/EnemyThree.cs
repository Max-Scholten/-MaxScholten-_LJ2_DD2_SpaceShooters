using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MaxScholten__LJ2_DD2_SpaceShooters.Models
{
    internal class EnemyThree :EnemyShip
    {

        public EnemyThree(int attackDamage, string spaceShipImage, int speed)
            : base("EnemyThree", health: 100, damage: attackDamage,speed:speed, spaceShipImage)
        {
        }
    }
}
