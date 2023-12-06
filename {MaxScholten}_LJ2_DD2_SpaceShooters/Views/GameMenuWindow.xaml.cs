using _MaxScholten__LJ2_DD2_SpaceShooters.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    /// Interaction logic for GameMenuWindow.xaml
    /// </summary>
    public partial class GameMenuWindow : INotifyPropertyChanged
        
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string PlayerName { get; set; } = string.Empty;

        public GameMenuWindow()
        {
            InitializeComponent();
        }

        private void BtnPlayGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnTournaments_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }

}