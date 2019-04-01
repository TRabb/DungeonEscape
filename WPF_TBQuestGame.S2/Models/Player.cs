using System;
using System.Collections.Generic;
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
        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

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
