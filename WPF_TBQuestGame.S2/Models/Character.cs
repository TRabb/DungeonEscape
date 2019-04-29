using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TBQuestGame.Models
{
    public class Character : ObservableObject
    {
        #region ENUMS

        protected enum Race
        {
            Human,
            Elf,
            Orc
        }

        #endregion

        #region FIELDS
        protected int _id;
        protected string _name;
        //protected int _locationId;
        #endregion

        #region PROPERTIES
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //public int LocationID
        //{
        //    get { return _locationId; }
        //    set { _locationId = value; }
        //}

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(int Id, string Name/*, int LocationID*/)
        {
            ID = _id;
            Name = _name;
            //LocationID = _locationId;
        }

        #endregion

        #region METHODS

        public virtual string DefaultGreeting()
        {
            return $"Hello my name is {_name}.";
        }

        #endregion

        #region OBJECTS

        protected Random random = new Random();

        #endregion
    }
}
