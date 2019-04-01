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
                LocationID = 10,
                Class = Player.ClassType.Wizard,
                Health = 100,
                Experience = 0,
                Age = 18,

            };
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

            gameMap.MapLocations[0, 0] = new Location()
            {

                Id = 1,
                Name = "Starting Room",
                Description = "Row 0 Column 0",
                Message = "You have woken up with a raging headache in" +
                          "\na very unfamiliar place. It seems to be some" +
                          "\nsort of cellar with a door to the east and a" +
                          "\ndoor to the south.",
                ModifiyExperiencePoints = 5,
                Accessible = true
     
            };
            gameMap.MapLocations[1, 0] = new Location()
            {

                Id = 2,
                Name = "Row 1 Column 0",
                Description = "Row 1 Column 0",
                Message = "Test 2",
                ModifiyExperiencePoints = 5,
                Accessible = true

            };
            gameMap.MapLocations[2, 0] = new Location()
            {

                Id = 3,
                Name = "Row 2 Column 0",
                Description = "Row 2 Column 0",
                Message = "Test 3",
                ModifiyExperiencePoints = 5,
                Accessible = true

            };
            gameMap.MapLocations[0, 1] = new Location()
            {

                Id = 4,
                Name = "Row 0 Column 1",
                Description = "Row 0 Column 1",
                Message = "Test 4",
                ModifiyExperiencePoints = 5,
                Accessible = true

            };
            gameMap.MapLocations[2, 1] = new Location()
            {

                Id = 5,
                Name = "Row 2 Column 1",
                Description = "Row 2 Column 1",
                Message = "Test 5",
                ModifiyExperiencePoints = 5,
                Accessible = true

            };
            gameMap.MapLocations[3, 1] = new Location()
            {

                Id = 6,
                Name = "Row 3 Column 1",
                Description = "Row 3 Column 1",
                Message = "Test 6",
                ModifiyExperiencePoints = 5,
                Accessible = true

            };
            gameMap.MapLocations[0, 2] = new Location()
            {

                Id = 7,
                Name = "Row 0 Column 2",
                Description = "Row 0 Column 2",
                Message = "Test 7",
                ModifiyExperiencePoints = 5,
                Accessible = true

            };
            gameMap.MapLocations[1, 2] = new Location()
            {

                Id = 8,
                Name = "Row 1 Column 2",
                Description = "Row 1 Column 2",
                Message = "Test 8",
                ModifiyExperiencePoints = 5,
                Accessible = true

            };
            gameMap.MapLocations[3, 2] = new Location()
            {

                Id = 9,
                Name = "Row 3 Column 2",
                Description = "Row 3 Column 2",
                Message = "Test 9",
                ModifiyExperiencePoints = 5,
                Accessible = true

            };
            gameMap.MapLocations[1, 3] = new Location()
            {

                Id = 10,
                Name = "Row 1 Column 3",
                Description = "Row 1 Column 3",
                Message = "Test 10",
                ModifiyExperiencePoints = 5,
                Accessible = true

            };
            gameMap.MapLocations[3, 3] = new Location()
            {

                Id = 11,
                Name = "Row 3 Column 3",
                Description = "Row 3 Column 3",
                Message = "Test 11",
                ModifiyExperiencePoints = 5,
                Accessible = true

            };
            gameMap.MapLocations[2, 3] = new Location()
            {

                Id = 12,
                Name = "Boss",
                Description = "Boss",
                Message = "Test 12",
                ModifiyExperiencePoints = 5,
                Accessible = true

            };




            return gameMap;
        }
    }
}
