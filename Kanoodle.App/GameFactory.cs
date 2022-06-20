using Kanoodle.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Kanoodle.App
{
    public static class GameFactory
    {
        private static Dictionary<string, Game> _games;
        public static Dictionary<string, Game> Games
        {
            get
            {

                if (_games == null)
                {
                    var g = JsonSerializer.Deserialize<IEnumerable<Game>>(File.ReadAllText("Games.json"));
                    _games = g.ToDictionary(m => m.Name, m => m);
                }

                return _games;
            }
        }



    }
}
