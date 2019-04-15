using System;
using System.Collections.Generic;
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
using WPF_TBQuestGame.Models;

namespace WPF_TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;

        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;
            InitializeComponent();
        }

        private void Button_UpMove_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveNorth();
        }

        private void Button_DownMove_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveSouth();
        }

        private void Button_RightMove_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveEast();
        }

        private void Button_LeftMove_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveWest();
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_PickUp_Click(object sender, RoutedEventArgs e)
        {
            if (RoomItemsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.AddItemToInventory();
            }

        }

        private void Button_PutDown_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.RemoveItemFromInventory();
            }
        }
    }
}
