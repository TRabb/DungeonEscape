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
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        private Player _player;

        public PlayerSetupView(Player player)
        {
            _player = player;

            InitializeComponent();

            SetupWindow();
        }

        private void SetupWindow()
        {
            List<string> Class = Enum.GetNames(typeof(Player.ClassType)).ToList();
            ComboBox_Class.ItemsSource = Class;

            PopUp_Error.Visibility = Visibility.Hidden;
        }

        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";

            if (TextBox_Name.Text == "")
            {
                errorMessage += "Player name is required.\n";
            }
            else
            {
                _player.Name = TextBox_Name.Text;
            }

            return errorMessage == "" ? true:false;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;

            if (IsValidInput(out errorMessage))
            {
                Enum.TryParse(ComboBox_Class.SelectionBoxItem.ToString(), out Player.ClassType classType);
                _player.Name = Name;

                Visibility = Visibility.Hidden;
            }
            else
            {
                PopUp_Error.Visibility = Visibility.Visible;
                PopUp_Error.Text = errorMessage;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
