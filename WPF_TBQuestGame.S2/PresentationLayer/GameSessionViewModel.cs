using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_TBQuestGame.Models;
using WPF_TBQuestGame.BusinessLayer;

namespace WPF_TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        #region FIELDS
        private Player _player;
        private List<string> _messages;
        private Map _gameMap;
        private Location _currentLocation;
        private Location _northLocation, _eastLocation, _southLocation, _westLocation;

        #endregion

        #region PROPERTIES
        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }
        }

        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                }
        }

        public Location NorthLocation
        {
            get { return _northLocation; }
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(HasNorthLocation));
            }
        }

        public Location EastLocation
        {
            get { return _eastLocation; }
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(HasEastLocation));
            }
        }

        public Location SouthLocation
        {
            get { return _southLocation; }
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(HasSouthLocation));
            }
        }

        public Location WestLocation
        {
            get { return _westLocation; }
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(HasWestLocation));
            }
        }
        public bool HasNorthLocation { get { return NorthLocation != null; } }
        public bool HasEastLocation { get { return EastLocation != null; } }
        public bool HasSouthLocation { get { return SouthLocation != null; } }
        public bool HasWestLocation { get { return WestLocation != null; } }
        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            List<string> initialMessages,
            Map gameMap,
            GameMapCoordinates currentLocationCoordinates)
        {
            _player = player;
            _messages = initialMessages;

            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = _gameMap.CurrentLocation;
            InitializeView();
            
        }
        #endregion

        #region METHODS

        private void InitializeView()
        {
            UpdateAvailableTravelPoints();
        }

        private void OnPlayerMove()
        {
            //
            // update player stats when in new location
            //
            if (!_player.HasVisited(_currentLocation))
            {
                //
                // add location to list of visited locations
                //
                _player.LocationsVisited.Add(_currentLocation);

                // 
                // update experience points
                //
                _player.Experience += _currentLocation.ModifiyExperiencePoints;

                //
                // update health
                //
                if (_currentLocation.ModifyHealth != 0)
                {
                    _player.Health += _currentLocation.ModifyHealth;
                    if (_player.Health > 100)
                    {
                        _player.Health = 100;
                    }
                }
                //
                // display a new message if available
                //
                OnPropertyChanged(nameof(MessageDisplay));
            }
        }

        private void UpdateAvailableTravelPoints()
        {
            //
            // reset travel location information
            //
            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;

            if (_gameMap.NorthLocation(_player) != null)
            {
                NorthLocation = _gameMap.NorthLocation(_player);
            }

            if (_gameMap.EastLocation(_player) != null)
            {
                EastLocation = _gameMap.EastLocation(_player);
            }

            if (_gameMap.SouthLocation(_player) != null)
            {
                SouthLocation = _gameMap.SouthLocation(_player);
            }

            if (_gameMap.WestLocation(_player) != null)
            {
                WestLocation = _gameMap.WestLocation(_player);
            }
        }

        public void MoveNorth()
        {
            if (HasNorthLocation)
            {
                _gameMap.MoveNorth();
                UpdateAvailableTravelPoints();
                CurrentLocation = _gameMap.CurrentLocation;
                //OnPlayerMove();              
            }
        }

        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.MoveEast();
                UpdateAvailableTravelPoints();
                CurrentLocation = _gameMap.CurrentLocation;
                //OnPlayerMove();
            }
        }

        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.MoveSouth();
                UpdateAvailableTravelPoints();
                CurrentLocation = _gameMap.CurrentLocation;
                //OnPlayerMove();
            }
        }

        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.MoveWest();
                UpdateAvailableTravelPoints();
                CurrentLocation = _gameMap.CurrentLocation;
                //OnPlayerMove();
            }
        }

        #endregion


    }
}
