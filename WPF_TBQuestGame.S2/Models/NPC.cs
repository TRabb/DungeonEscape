using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TBQuestGame.Models
{
    public abstract class NPC : Character
    {
        public string Description { get; set; }
        public string Information
        {
            get
            {
                return InformationText();
            }
            set
            {

            }
        }

        public NPC()
        {

        }

        public NPC(int id, string name, string description)
            : base(id, name)
        {
            ID = id;
            Name = name;
            Description = description;
        }

        protected abstract string InformationText();

    }
}
