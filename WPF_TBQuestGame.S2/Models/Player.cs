using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TBQuestGame.Models
{
    public class Player : Character
    {
        public enum ClassType
        {
            Warrior,
            Archer,
            Wizard      
        }
        #region FIELDS
        protected int _health;
        protected int _exp;
        protected ClassType _classType;
        protected string ImageFileName;
        private int _age;
        private List<Location> _locationsVisited;
        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _weapon;
        private ObservableCollection<GameItem> _flask;
        private ObservableCollection<GameItem> _key;

        #endregion

        #region PROPERTIES
        public ClassType Class
        {
            get { return _classType; }
            set { _classType = value; }
        }


        public int Experience
        {
            get { return _exp; }
            set {
                _exp = value;
                OnPropertyChanged(nameof(Experience));
                }
        }


        public int Health
        {
            get { return _health; }
            set {
                _health = value;
                OnPropertyChanged(nameof(Health));
                }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public ObservableCollection<GameItem> Weapon
        {
            get { return _weapon; }
            set { _weapon = value; }
        }

        public ObservableCollection<GameItem> Flask
        {
            get { return _flask; }
            set { _flask = value; }
        }

        public ObservableCollection<GameItem> Key
        {
            get { return _key; }
            set { _key = value; }
        }

        #endregion

        #region CONSTRUCTORS
        public Player()
        {
            _locationsVisited = new List<Location>();
            _weapon = new ObservableCollection<GameItem>();
            _flask = new ObservableCollection<GameItem>();
            _key = new ObservableCollection<GameItem>();
        }
        #endregion

        #region METHODS

        public void UpdateInventoryCategories()
        {
            Flask.Clear();
            Weapon.Clear();
            Key.Clear();

            foreach (var gameItem in _inventory)
            {
                if (gameItem is Flask) Flask.Add(gameItem);
                if (gameItem is Weapon) Weapon.Add(gameItem);
                if (gameItem is Key) Key.Add(gameItem);
            }
        }
        /// <summary>
        /// remove selected item from inventory
        /// </summary>
        /// <param name="selectedGameItem">selected item</param>
        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Add(selectedGameItem);
            }
        }

        /// <summary>
        /// remove selected item from inventory
        /// </summary>
        /// <param name="selectedGameItem">selected item</param>
        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Remove(selectedGameItem);
            }
        }

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        public override string DefaultGreeting()
        {
            string article = "a";

            List<string> vowels = new List<string>() { "A", "E", "I", "O", "U" };

            if (vowels.Contains(Class.ToString().Substring(0, 1))) ;
            {
                article = "an";
            }

            return $"Hello, my name is {_name} and I am {article} {Class} trying to escape this dungeon.";
        }

        #endregion

    }
}
