using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TBQuestGame.Models
{
    public class Flask : GameItem
    {

        public int HealthChange { get; set; }

        public Flask(int id, string name, int value, int healthChange, string description, int experienecePoints)
            : base(id, name, value, description, experienecePoints)
        {
            HealthChange = healthChange;
        }

        public override string InformationString()
        {
            if (HealthChange != 0)
            {
                return $"{Name}: {Description}\nHealth: {HealthChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }
    }
    



}
