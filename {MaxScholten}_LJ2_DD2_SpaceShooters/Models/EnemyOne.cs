using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MaxScholten__LJ2_DD2_SpaceShooters.Models
{
    internal class EnemyOne :EnemyShip
    {

        public EnemyOne(int attackDamage, string spaceShipImage, int speed)
            : base("EnemyOne", health: 100, damage: attackDamage,speed:speed, spaceShipImage)
        {

        }
    }
}
