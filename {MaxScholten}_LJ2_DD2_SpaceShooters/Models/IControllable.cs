using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MaxScholten__LJ2_DD2_SpaceShooters.Models
{
    // Interface for controlling the player ship
    internal interface IControllable
    {
        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
        void Shoot();
        void TakeDamage(int damage);
    }
}
