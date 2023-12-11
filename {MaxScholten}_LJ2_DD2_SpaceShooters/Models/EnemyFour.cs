using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MaxScholten__LJ2_DD2_SpaceShooters.Models
{
    internal class EnemyFour :EnemyShip
    {

        public EnemyFour(int attackDamage, string spaceShipImage, int speed)
            : base("EnemyFour", health: 100, damage: attackDamage,speed:speed, spaceShipImage)
        {
        }
    }
}
