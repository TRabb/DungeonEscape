using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TBQuestGame.Models
{
    public class Key : GameItem
    {
        public enum UseActionType
        {
            OPENLOCATION,
            DAMAGEPLAYER
        }

        public UseActionType UseAction { get; set; }

        public Key(int id, string name, int value, string description, int experiencePoints)
                : base(id, name, value, description, experiencePoints)
        {
            UseAction = UseAction;
        }

        public  override string InformationString()
        {
            return $"{Name}: {Description}\nValue: {Value}";
        }
    }
}
