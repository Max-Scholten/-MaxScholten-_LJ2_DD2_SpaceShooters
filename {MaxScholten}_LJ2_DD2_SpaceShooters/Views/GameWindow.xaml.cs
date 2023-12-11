using _MaxScholten__LJ2_DD2_SpaceShooters.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _MaxScholten__LJ2_DD2_SpaceShooters.Views
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window , INotifyPropertyChanged
    {
        public GameWindow()
        {
            InitializeComponent();
            playerShip = new PlayerShip("PlayerName");

        }
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
        #region PlayingField
        private const int boundary = 20;
        private readonly int leftBorder = boundary;
        private readonly int topBorder = (int)(SystemParameters.PrimaryScreenHeight - boundary - 60);
        private readonly int rightBorder = (int)(SystemParameters.PrimaryScreenWidth - boundary - 60);
        private readonly int bottomBorder = boundary;
        
        #endregion
        #region ControlKeys
        private bool leftKeyPressed;
        private bool upKeyPressed;
        private bool rightKeyPressed;
        private bool downKeyPressed;
        private bool spaceKeyPressed;
        private long startTime;
        private PlayerShip playerShip;

        #endregion
        #region
        private readonly Random random = new Random();
        private readonly Stopwatch enemyStopWatch = new Stopwatch();
        private readonly Stopwatch bulletStopWatch = new Stopwatch();
        private const int enemySpawnRate = 400; // Adjust the value as needed


        #endregion
        #region Enemies
        private int randomEnemyIndex;
        private const string assetLocation = "pack://application:,,,/Assets";
        private readonly List<EnemyShip> enemyShips = new()
        {
                    new EnemyOne(attackDamage: 5,
                spaceShipImage : $"{assetLocation}/enemySpriteOne.png", speed: 20),
                    new EnemyTwo(attackDamage: 10,
                spaceShipImage : $"{assetLocation}/enemySpriteTwo.png", speed: 10),
                    new EnemyThree(attackDamage: 15,
                spaceShipImage : $"{assetLocation}/enemySpriteThree.png", speed: 5),
                    new EnemyFour(attackDamage: 20,
                spaceShipImage : $"{assetLocation}/enemySpriteFour.png", speed: 10)
        };
        #endregion
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            // ... (existing code for OnKeyDown)
            if (e.Key == Key.Left || e.Key == Key.A)
            {
                leftKeyPressed = true;
            }
            if (e.Key == Key.Right || e.Key == Key.D)
            {
                rightKeyPressed = true;
            }
            if (e.Key == Key.Up || e.Key == Key.W)
            {
                upKeyPressed = true;
            }
            if (e.Key == Key.Down || e.Key == Key.S)
            {
                downKeyPressed = true;
            }
            if (e.Key == Key.Space)
            {
                spaceKeyPressed = true;
            }

        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            // ... (existing code for OnKeyUp)
            if (e.Key == Key.Left || e.Key == Key.A)
            {
                leftKeyPressed = false;
            }
            if (e.Key == Key.Right || e.Key == Key.D)
            {
                rightKeyPressed = false;
            }
            if (e.Key == Key.Up || e.Key == Key.W)
            {
                upKeyPressed = false;
            }
            if (e.Key == Key.Down || e.Key == Key.S)
            {
                downKeyPressed = false;
            }
            if (e.Key == Key.Space)
            {
                spaceKeyPressed = false;

            }

        }

        

        private void GameLoop(object sender, EventArgs e)
        {


            // ... (existing code for GameLoop)
            GameModel gameModel = new GameModel();
            gameModel.ElapsedTime = Stopwatch.GetElapsedTime(startTime);

            List<Rectangle> enemies =
                GameCanvas.Children.OfType<Rectangle>()
                .Where(r => r.Tag is EnemyShip).ToList();
            List<Rectangle> bullets =
                GameCanvas.Children.OfType<Rectangle>()
                .Where(r => r.Tag is string && r.Tag.ToString() == "bullet").ToList();

            DrawEnemy();
            ProcesPlayerInteraction();
            UpdateEnemy(enemies, bullets);
            CheckGameOver();
            Reset(enemies, bullets);
        }

        

        private void UpdateEnemy(List<Rectangle> enemies, List<Rectangle> bullets)
        {
            Rect playerHitBox = new(
                Canvas.GetLeft(PlayerShip),
                Canvas.GetBottom(PlayerShip),
                PlayerShip.Width, PlayerShip.Height);

            List<Rectangle> enemiesToRemove = new List<Rectangle>();
            List<Rectangle> bulletsToRemove = new List<Rectangle>();

            foreach (Rectangle enemy in enemies)
            {
                Rect enemyHitBox = new(
                    Canvas.GetLeft(enemy),
                    Canvas.GetBottom(enemy),
                    enemy.Width, enemy.Height);

                if (IsPlayerHit(playerHitBox, enemyHitBox))
                {

                    EnemyShip currentEnemy = (EnemyShip)enemy.Tag;
                    GameModel.HealthPoints -= currentEnemy.AttackDamage;
                    enemiesToRemove.Add(enemy);
                }

                foreach (Rectangle bullet in bullets)
                {
                    Rect bulletHitBox = new(
                        Canvas.GetLeft(bullet),
                        Canvas.GetBottom(bullet),
                        bullet.Width, bullet.Height);

                    if (IsBulletHit(enemyHitBox, bulletHitBox))
                    {
                        enemiesToRemove.Add(enemy);
                        bulletsToRemove.Add(bullet);
                        GameModel.Score += 1;
                    }
                }
            }

            // Remove enemies and bullets outside the loop
            foreach (var enemyToRemove in enemiesToRemove)
            {
                GameCanvas.Children.Remove(enemyToRemove);
            }

            foreach (var bulletToRemove in bulletsToRemove)
            {
                GameCanvas.Children.Remove(bulletToRemove);
            }
        }

        private bool IsPlayerHit(Rect playerHitBox, Rect enemyHitBox)
        {
            return playerHitBox.IntersectsWith(enemyHitBox);
        }

        private bool IsBulletHit(Rect enemyHitBox, Rect bulletHitBox)
        {
            return enemyHitBox.IntersectsWith(bulletHitBox);
        }

        private void DrawBullet()
        {
            // ... (implementation for DrawBullet)
            double deltaTime = bulletStopWatch.ElapsedMilliseconds;
            if (deltaTime > playerShip.FireRate)
            {
                // ZIE DE CODE HIERNA
                bulletStopWatch.Restart();
            }

            Rectangle bullet = new()
            {
                Tag = "bullet",
                Height = 20,
                Width = 5,
                Fill = Brushes.White,
                Stroke = Brushes.Purple
            };
            Canvas.SetLeft(bullet, Canvas.GetLeft(PlayerShip    ) + PlayerShip.Width / 2);
            Canvas.SetBottom(bullet, Canvas.GetBottom(PlayerShip    ) + bullet.Height);
            GameCanvas.Children.Add(bullet);

        }

        private void ProcesPlayerInteraction()
        {
            if (leftKeyPressed && Canvas.GetLeft(PlayerShip) > leftBorder)
            {
                playerShip.MoveLeft();
            }
            if (rightKeyPressed && Canvas.GetLeft(PlayerShip) < rightBorder)
            {
                playerShip.MoveRight();
            }
            if (upKeyPressed && Canvas.GetBottom(PlayerShip) < topBorder)
            {
                playerShip.MoveUp();
            }
            if (downKeyPressed && Canvas.GetBottom(PlayerShip) > bottomBorder)
            {
                playerShip.MoveDown();
            }
            if (spaceKeyPressed)
            {
                DrawBullet();
            }

            // Update the player's ship position based on the calculated speed
            Canvas.SetLeft(PlayerShip, Canvas.GetLeft(PlayerShip) - playerShip.XSpeed);
            Canvas.SetBottom(PlayerShip, Canvas.GetBottom(PlayerShip) - playerShip.YSpeed);

            // Ensure the ship stays within the boundaries
            if (Canvas.GetLeft(PlayerShip) < leftBorder)
            {
                Canvas.SetLeft(PlayerShip, leftBorder);
            }
            if (Canvas.GetLeft(PlayerShip) > rightBorder)
            {
                Canvas.SetLeft(PlayerShip, rightBorder);
            }
            if (Canvas.GetBottom(PlayerShip) < bottomBorder)
            {
                Canvas.SetBottom(PlayerShip, bottomBorder);
            }
            if (Canvas.GetBottom(PlayerShip) > topBorder)
            {
                Canvas.SetBottom(PlayerShip, topBorder);
            }

            // Update the player's ship speed
            playerShip.UpdateSpeed();
        }

        private void DrawEnemy()
        {
            randomEnemyIndex = new Random().Next(0, enemyShips.Count);  // Initialize the variable

            EnemyShip randomEnemy = enemyShips[randomEnemyIndex];
            ImageBrush enemySprite = randomEnemy.SpaceShipImage;

            Rectangle enemy = new()
            {
                Tag = randomEnemy,
                Height = 60,
                Width = 60,
                Fill = enemySprite
            };

            Canvas.SetBottom(enemy, topBorder + 200);
            Canvas.SetLeft(enemy, random.Next(leftBorder, rightBorder));
            GameCanvas.Children.Add(enemy);

            // ... (implementation for DrawEnemy)
            double deltaTime = enemyStopWatch.ElapsedMilliseconds;
            if (deltaTime > enemySpawnRate)
            {
                // Draw enemy: de code hiervoor
                enemyStopWatch.Restart();
            }
        }


        private void CheckGameOver()
        {
            // ... (implementation for CheckGameOver)
        }

        private void Reset(List<Rectangle> enemies, List<Rectangle> bullets)
        {
            // ... (implementation for Reset)
            foreach (Rectangle enemy in enemies)
            {
                EnemyShip currentEnemy = (EnemyShip)enemy.Tag;
                if (enemy.Height < bottomBorder - 60)
                {
                    GameCanvas.Children.Remove(enemy);
                }
                else
                {
                    double enemyPosition = Canvas.GetBottom(enemy);
                    Canvas.SetBottom(enemy, enemyPosition - currentEnemy.Speed);
                }
            }

            foreach (Rectangle bullet in bullets)
            {
                if (bullet.Height > topBorder + 60)
                {
                    GameCanvas.Children.Remove(bullet);
                }
                else
                {
                    double bulletPosition = Canvas.GetBottom(bullet);
                    Canvas.SetBottom(bullet, bulletPosition + 20);
                }
            }

        }
    }
}
