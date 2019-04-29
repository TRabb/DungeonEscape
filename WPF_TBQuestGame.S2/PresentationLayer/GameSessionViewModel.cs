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
        private string _currentLocationInformation;
        private NPC _currentNPC;
        private GameItem _currentGameItem;

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
                _currentLocationInformation = _currentLocation.Description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
                }
        }

        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
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

        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }

        public NPC CurrentNPC
        {
            get { return _currentNPC; }
            set
            {
                _currentNPC = value;
                OnPropertyChanged(nameof(CurrentNPC));
            }
        }
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
            _player.UpdateInventoryCategories();
            _currentLocationInformation = CurrentLocation.Description;
        }
        #endregion

        #region HELPER

        private int DieRoll(int sides)
        {
            return random.Next(1, sides + 1);
        }

        #endregion


        #region MOVEMENT
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
                OnPlayerMove();              
            }
        }

        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.MoveEast();
                UpdateAvailableTravelPoints();
                CurrentLocation = _gameMap.CurrentLocation;
                OnPlayerMove();
            }
        }

        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.MoveSouth();
                UpdateAvailableTravelPoints();
                CurrentLocation = _gameMap.CurrentLocation;
                OnPlayerMove();
            }
        }

        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.MoveWest();
                UpdateAvailableTravelPoints();
                CurrentLocation = _gameMap.CurrentLocation;
                OnPlayerMove();
            }
        }
        #endregion

        #region ACTIONS

        /// <summary>
        /// add selected item
        /// </summary>
        /// <param name="selectedGameItem"></param>
        public void AddItemToInventory()
        {
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                OnPlayerPickUp(selectedGameItem);

            }
        }

        /// <summary>
        /// remove selected item
        /// </summary>
        /// <param name="selectedGameItem"></param>
        public void RemoveItemFromInventory()
        {
            if (_currentGameItem != null)
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);

            }
        }

        private void OnPlayerPickUp(GameItem gameItem)
        {
            _player.Experience += gameItem.ExperiencePoints;
        }

        private void OnPlayerPutDown(GameItem gameItem)
        {
            _player.Experience -= gameItem.ExperiencePoints;
        }

        public void OnUseGameItem()
        {
            switch (_currentGameItem)
            {
                case Flask flask:
                    ProcessFlaskUse(flask);
                    break;
                case Key key:
                    ProcessKeyUse(key);
                    break;
                default:
                    break;
            }
        }

        private void ProcessFlaskUse(Flask flask)
        {
            if (_player.Health <= 100)
            {
                _player.Health += flask.HealthChange;
                _player.RemoveGameItemFromInventory(_currentGameItem);
                if (_player.Health > 100)
                {
                    _player.Health = 100;
                }
            }
            else
            {
                CurrentLocationInformation = "Your health is already full!";
            }

        }


        private void ProcessKeyUse(Key key)
        {
            string message;

            switch (key.UseAction)
            {
                case Key.UseActionType.OPENLOCATION:
                    message = _gameMap.OpenLocationsByKey(key.Id);
                    CurrentLocationInformation = key.UseMessage;
                    break;
                case Key.UseActionType.DAMAGEPLAYER:
                    break;
                default:
                    break;
            }
        }

        public void OnPlayerTalkTo()
        {
            if (CurrentNPC != null && CurrentNPC is ISpeak)
            {
                ISpeak speakingNPC = CurrentNPC as ISpeak;
                CurrentLocationInformation = speakingNPC.Speak();
            }
        }

        #endregion

        #region BATTLE METHODS

        private void Battle()
        {
            if (_currentNPC is IBattle)
            {
                IBattle battleNPC = _currentNPC as IBattle;
                int playerHitPoints = _player.Health;
                int battleNPCHitPoints = 0;
                string battleInformation = "";

                //if (_player.CurrentWeapon != null)
                //{
                //    playerHitPoints = CalculatePlayerHitPoints();
                //}
                //else
                //{
                //    battleInformation = "You are entering battle without a weapon!";
                //}

                if (battleNPC.CurrentWeapon != null)
                {
                    battleNPCHitPoints = CalculateNPCHitPoints(battleNPC);
                }
                else
                {
                    battleInformation = $"You are entering battle against {_currentNPC.Name} who appears to be unarmed.";
                }

                battleInformation +=
                    $"\nPlayer: {_player.BattleMode}      Hit Points: {playerHitPoints}" + Environment.NewLine +
                    $"NPC: {battleNPC.BattleMode}       Hit Points: {battleNPCHitPoints}" + Environment.NewLine;

                if (playerHitPoints >= battleNPCHitPoints)
                {
                    battleInformation += $"You have slain {_currentNPC.Name}";
                    _currentLocation.NPCs.Remove(_currentNPC);
                }
                else
                {
                    battleInformation += $"You have been slain by {_currentNPC.Name}";
                    _player.Health = 0;
                }
                CurrentLocationInformation = battleInformation;
                if (_player.Health <= 0) OnPlayerDies("You have been slain.");

            }
            else
            {
                CurrentLocationInformation = "This NPC is angry that you tried to attack them \nand smacked you across the face!";
                _player.Health -= 5;
            }
        }

        private BattleModeName NPCBattleResponse()
        {
            BattleModeName npcBattleResponse = BattleModeName.RETREAT;

            switch (DieRoll(2))
            {
                case 1:
                    npcBattleResponse = BattleModeName.ATTACK;
                    break;
                case 2:
                    npcBattleResponse = BattleModeName.DEFEND;
                    break;
            }

            return npcBattleResponse;
        }

        private int CalculatePlayerHitPoints()
        {
            int playerHitPoints = 0;

            switch (_player.BattleMode)
            {
                case BattleModeName.ATTACK:
                    playerHitPoints = _player.Attack();
                    break;
                case BattleModeName.DEFEND:
                    playerHitPoints = _player.Defend();
                    break;
            }

            return playerHitPoints;
        }

        private int CalculateNPCHitPoints(IBattle battleNPC)
        {
            int battleNPCHitPoints = 0;
            
            switch (NPCBattleResponse())
            {
                case BattleModeName.ATTACK:
                    battleNPCHitPoints = battleNPC.Attack();
                    _player.Health -= 5;
                    break;
                case BattleModeName.DEFEND:
                    battleNPCHitPoints = battleNPC.Defend();
                    _player.Health -= 3;
                    break;
                default:
                    break;
            }

            return battleNPCHitPoints;
        }

        public void OnPlayerAttack()
        {
            _player.BattleMode = BattleModeName.ATTACK;
            Battle();
        }

        public void OnPlayerDefend()
        {
            _player.BattleMode = BattleModeName.DEFEND;
            Battle();
        }

        private void OnPlayerDies(string message)
        {
            string messagetext = message +
                "\n\nWould you like to play again?";

            string titleText = "Death";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuitApplication();
                    break;
            }
        }

        private void ResetPlayer()
        {
            Environment.Exit(0);
        }

        private void QuitApplication()
        {
            Environment.Exit(0);
        }
        #endregion

        #region OBJECTS

        private Random random = new Random();

        #endregion

    }
}
