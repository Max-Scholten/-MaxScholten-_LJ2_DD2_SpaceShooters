using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace _MaxScholten__LJ2_DD2_SpaceShooters.Models
{
    internal abstract class EnemyShip : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // Properties
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int AttackDamage { get; set; }
        public int Speed { get; set; }
        public ImageBrush SpaceShipImage { get; set; }

        // Constructor
        protected EnemyShip(string name, int health, int damage, int speed,string spaceShipImage)
        {
            Name = name;
            HealthPoints = health;
            AttackDamage = damage;
            Speed = speed;
            SpaceShipImage = new ImageBrush() { ImageSource = new BitmapImage(new Uri(spaceShipImage)) };
        }

        // Method to describe the enemy (can be overridden by derived classes)
        public virtual void EnemyDescription()
        {
            Console.WriteLine($"Enemy Ship: {Name}, Health: {HealthPoints}, Damage: {AttackDamage}, Speed: {Speed}");
        }

        // Implementation of the IAggressive interface
        public void Attack()
        {
            Console.WriteLine($"{Name} is attacking! Inflicting {AttackDamage} damage.");
        }

        // Method to simulate the enemy ship taking damage
        public void TakeDamage(int amount)
        {
            HealthPoints -= amount;
            Console.WriteLine($"{Name} took {amount} damage. Remaining health: {HealthPoints}");
        }
    }
}
