using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _MaxScholten__LJ2_DD2_SpaceShooters.Models
{
    internal abstract class EnemyShip 
    {
        // Properties
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public ImageBrush SpaceShipImage { get; set; }

        // Constructor
        protected EnemyShip(string name, int health, int damage, string spaceShipImage)
        {
            Name = name;
            Health = health;
            Damage = damage;
            SpaceShipImage = new ImageBrush() { ImageSource = new BitmapImage(new Uri(spaceShipImage)) };
        }

        // Method to describe the enemy (can be overridden by derived classes)
        public virtual void EnemyDescription()
        {
            Console.WriteLine($"Enemy Ship: {Name}, Health: {Health}, Damage: {Damage}");
        }

        // Implementation of the IAggressive interface
        public void Attack()
        {
            Console.WriteLine($"{Name} is attacking! Inflicting {Damage} damage.");
        }

        // Method to simulate the enemy ship taking damage
        public void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} took {amount} damage. Remaining health: {Health}");
        }
    }
}
