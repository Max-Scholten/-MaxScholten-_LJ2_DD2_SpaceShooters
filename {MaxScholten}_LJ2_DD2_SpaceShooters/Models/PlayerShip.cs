using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MaxScholten__LJ2_DD2_SpaceShooters.Models
{
    internal class PlayerShip : IControllable
    {
        // Properties
        public int Health { get; set; }
        public int Score { get; set; }
        public int Speed { get; set; }
        public double XSpeed { get; set; }
        public double YSpeed { get; set; }
        public double FireRate { get; set; }
        public double Friction { get; set; }

        // Constructor
        public PlayerShip(string name)
        {
            Health = 100;
            Score = 0;
            Speed = 5;
            XSpeed = 0;
            YSpeed = 0;
            FireRate = 1.0; // Example value, adjust as needed
            Friction = 0.95; // Example value, adjust as needed
            
        }

        // Method to move the player's ship left
        public void MoveLeft()
        {
            XSpeed += Speed;
        }

        // Method to move the player's ship right
        public void MoveRight()
        {
            XSpeed -= Speed;
        }

        // Method to move the player's ship up
        public void MoveUp()
        {
            YSpeed -= Speed;
        }

        // Method to move the player's ship down
        public void MoveDown()
        {
            YSpeed += Speed;
        }

        // Method to update the speed of the player's ship
        public void UpdateSpeed()
        {
            XSpeed *= Friction;
            YSpeed *= Friction;
        }

        // Other methods like shooting and taking damage can be added as needed
        public void Shoot()
        {
            // Implement shooting logic here
            Console.WriteLine("Player's ship is shooting!");
        }

        public void TakeDamage(int damage)
        {
            // Implement damage-taking logic here
            Health -= damage;
            Console.WriteLine($"Player's ship took {damage} damage. Health: {Health}");
        }
    }
 
}

