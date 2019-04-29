using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TBQuestGame.Models;

namespace WPF_TBQuestGame.DataLayer
{
    public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                ID = 1,
                Name = "Tanner",
                //LocationID = 10,
                Class = Player.ClassType.Wizard,
                Health = 100,
                Experience = 0,
                Age = 18,
                Inventory = new ObservableCollection<GameItem>()
                {
                    GameItemByID(1002),
                },
                CurrentWeapon = GameItemByID(1002) as Weapon

            };
        }

        private static GameItem GameItemByID(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "You got lost and now you're in a dungeon and must fight your way back to the surface. Goodluck Chief."
            };
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }

        public static Map GameMapData()
        {
            int rows = 4;
            int columns = 4;

            Map gameMap = new Map(rows, columns);

            gameMap.StandardGameItems = StandardGameItems();

            gameMap.MapLocations[0, 0] = new Location()
            {

                Id = 1,
                Name = "Holding Cell",
                Message = "You have woken up with a raging headache in a very unfamiliar place." +
                          "\nIt seems to be some sort of cellar with a door to the east and a door" +
                          "\nto the south.",
                ModifiyExperiencePoints = 0,
                Accessible = true,
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemByID(2000) 
                }
     
            };
            gameMap.MapLocations[1, 0] = new Location()
            {

                Id = 2,
                Name = "Wine Cellar",
                Message = "As you enter the room there are barrels with taps stacked all over." +
                          "\nYou notice a man sitting in the corner who seems to be very drunk.",
                ModifiyExperiencePoints = 5,
                Accessible = true,
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemByID(2002)
                },

                NPCs = new ObservableCollection<NPC>()
                {
                    NPCByID(5000)
                }

            };
            gameMap.MapLocations[2, 0] = new Location()
            {

                Id = 3,
                Name = "Southern Cellar",
                Message = "You enter a dimmly lit room and pick up on a weird smell. You start" +
                          "\nto hear a noise infront of you and notice a figure making it's way" +
                          "\ntowards you. It seems to be a giant rat!" +
                          "\n\nWhat would you like to do?",
                ModifiyExperiencePoints = 15,
                Accessible = true,
                NPCs = new ObservableCollection<NPC>()
                {
                    NPCByID(6000)
                }

            };
            gameMap.MapLocations[0, 1] = new Location()
            {

                Id = 4,
                Name = "Storage Cellar",
                Message = "You immediately notice stacks of wooden boxes. You hear a noise" +
                          "\ncoming from behind a stack of boxes. There seems to be someone" +
                          "\nhere with you...",
                ModifiyExperiencePoints = 5,
                Accessible = true,
                NPCs = new ObservableCollection<NPC>()
                {
                    NPCByID(5001)
                }

            };
            gameMap.MapLocations[2, 1] = new Location()
            {

                Id = 5,
                Name = "Sorting Cellar",
                Message = "You see various bottles of alcohol sitting out and see some figure" +
                          "\nsleeping in the corner. There is a door right next to where he is" +
                          "\nsleeping." +
                          "\n\nWhat would you like to do?",
                ModifiyExperiencePoints = 25,
                Accessible = true,
                NPCs = new ObservableCollection<NPC>
                {
                    NPCByID(6002)
                }

            };
            gameMap.MapLocations[3, 1] = new Location()
            {

                Id = 6,
                Name = "Holding Cells",
                Message = "As you enter there seems to be multiple holding cells with people" +
                          "\ninside. They all look underfed and on their last leg.",
                ModifiyExperiencePoints = 5,
                Accessible = true,
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemByID(3000)
                },

                NPCs = new ObservableCollection<NPC>
                {
                    NPCByID(5002),
                    NPCByID(5003)
                }
            };
            gameMap.MapLocations[0, 2] = new Location()
            {

                Id = 7,
                Name = "Sorting Cellar",
                Message = "You hear a shuffle as you enter the room and a rabid dog rapidly" +
                          "\nstarts approaching you." +
                          "\n\nWhat would you like to do?",
                ModifiyExperiencePoints = 15,
                Accessible = true,
                NPCs = new ObservableCollection<NPC>
                {
                    NPCByID(6001)
                }

            };
            gameMap.MapLocations[1, 2] = new Location()
            {

                Id = 8,
                Name = "Dark Room",
                Message = "As you enter you are immediatly hit over the head with something" +
                          "\nand get knocked to the floor. You hear a man start to yell for backup" +
                          "\n\nWhat would you like to do?",
                ModifiyExperiencePoints = 25,
                ModifyHealth = -10,
                Accessible = true,
                NPCs = new ObservableCollection<NPC>
                {
                    NPCByID(6002)
                }

            };
            gameMap.MapLocations[3, 2] = new Location()
            {

                Id = 9,
                Name = "Execution Room",
                Message = "You notice multiple contraptions that are stained with blood. You" +
                          "\ndecide to look around and try and find some supplies to help you" +
                          "\nalong your journy.",
                ModifiyExperiencePoints = 35,
                Accessible = true,
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemByID(1000),
                    GameItemByID(2000),
                    GameItemByID(2001)
                }

            };
            gameMap.MapLocations[1, 3] = new Location()
            {

                Id = 10,
                Name = "Resting Area",
                Message = "As you are looking around you see a small camp setup right outside" +
                          "\nof a giant door. There is a man cooking some sort of soup over a fire" +
                          "\nand he gestures for you to come and sit with him.",
                ModifiyExperiencePoints = 5,
                Accessible = true,
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemByID(2000)
                },

                NPCs = new ObservableCollection<NPC>
                {
                    NPCByID(5004)
                }

            };
            gameMap.MapLocations[3, 3] = new Location()
            {

                Id = 11,
                Name = "Main Entrance",
                Message = "As you peek around the corner you see a guard infront of a giant" +
                          "\ndoor. The guard notices your head peak around the corner and yells" +
                          "\nat you." +
                          "\n\nWhat would you like to do?",
                ModifiyExperiencePoints = 35,
                Accessible = true,
                NPCs = new ObservableCollection<NPC>
                {
                    NPCByID(6002)
                }

            };
            gameMap.MapLocations[2, 3] = new Location()
            {

                Id = 12,
                Name = "The Lair",
                Message = "As you enter there is a man sitting in a throne turned away from" +
                          "\nyou. He slowly turns and gives you a glare you will never forget.",
                ModifiyExperiencePoints = 100,
                Accessible = false,
                RequiredKeyID = 3000,
                NPCs = new ObservableCollection<NPC>
                {
                    NPCByID(6003)
                }

            };

            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1000, "Rusty Longsword", 25, 1, 5, "This longsword is very worn and seems to have been used in many battles.", 10),
                new Weapon(1001, "Oak Shortbow", 25, 1, 5, "This shortbow seems to be made of oak and the string is starting to fray.", 10),
                new Weapon(1002, "Wand of Spark", 25, 1, 5, "This wand looks like a old branch that \nwas broken off many years ago.", 10),
                new Weapon(1003, "Bite", 0, 1, 3, "A ferocious bite.", 0),
                new Weapon(1004, "Longsword", 50, 2, 7, "A longsword used by all guards", 20),
                new Weapon(1005, "Sword of the Ages", 1000, 10, 20, "Only legends wield this sword", 100),
                new Flask(2000, "Flask of Healing", 10, 25, "A flask that heals you for 25 hitpoints.", 5),
                new Flask(2001, "Mysterious Liquid", 25, 25, "I'm not really sure what this is...", 5),
                new Flask(2002, "Bottle of Wine", 50, 0, "A bottle of the finest wine that probably \nwould taste good.", 5),
                new Flask(2003, "Keg of Ale", 100, 0, "A keg of the finest ale.", 50),
                new Key(3000, "Mysterious Key", 100, "A key that may be useful in the future.", 25)
            };
        }

        #region NPCs

        private static NPC NPCByID(int id)
        {
            return NPCs().FirstOrDefault(i => i.ID == id);
        }

        public static List<NPC> NPCs()
        {
            return new List<NPC>()
            {
                new Merchants()
                {
                    ID = 5000,
                    Name = "Phillip",
                    Description = "A very old man that seems to be very \ninterested in you.",
                    Messages = new List<string>()
                    {
                        "What are you doing down here!",
                        "Be careful on your adventures."
                    }
                },

                new Merchants()
                {
                    ID = 5001,
                    Name = "Charles",
                    Description = "A young, stocky man giving you a very \nweird look as you walk in.",
                    Messages = new List<string>()
                    {
                        "What are you doing down here!",
                        "Be careful on your adventures."
                    }
                },

                new Merchants()
                {
                    ID = 5002,
                    Name = "George",
                    Description = "A very weak old man that is under fed.",
                    Messages = new List<string>()
                    {
                        "I stole a key off the guard and dropped it on the" +
                        "\nfloor. Im not sure what it unlocks but take it."
                    }
                },

                new Merchants()
                {
                    ID = 5003,
                    Name = "Jacob",
                    Description = "A man laying on the floor who is almost" +
                                  "\na skeleton.",
                    Messages = new List<string>()
                    {
                        "...help......me..."
                    }
                },

                new Merchants()
                {
                    ID = 5004,
                    Name = "William",
                    Description = "A well fed man who seems friendly.",
                    Messages = new List<string>()
                    {
                        "Through this door is a very powerful man. Take" +
                        "\nsome things from my crate over there."
                    }

                },

                new Enemies()
                {
                    ID = 6000,
                    Name = "Giant Rat",
                    Description = "A giant rat that seems to have feasted" +
                                  "\noff of the weak to survive.",
                    SkillLevel = 20,
                    CurrentWeapon = GameItemByID(1003) as Weapon
                },

                new Enemies()
                {
                    ID = 6001,
                    Name = "Rabid Dog",
                    Description = "A very angry rabid dog",
                    SkillLevel = 20,
                    CurrentWeapon = GameItemByID(1003) as Weapon
                },
                new Enemies()
                {
                    ID = 6002,
                    Name = "Guard",
                    Description = "A guard equipped with heavy armor and" +
                                   "\na sword.",
                    SkillLevel = 30,
                    CurrentWeapon = GameItemByID(1004) as Weapon
                },
                new Enemies()
                {
                    ID = 6003,
                    Name = "Lord of the Land",
                    Description = "This man controls everything" +
                                  "\nthat happens around here.",
                    SkillLevel = 50,
                    CurrentWeapon = GameItemByID(1005) as Weapon
                }
            };
        }

        #endregion

    }
}
