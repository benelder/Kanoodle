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
        public static Dictionary<string, Game> Games
        {
            get
            {
                // intentionally not caching the deserialized result into a private field
                // so that newly added games are immediately available at runtime
                return JsonSerializer.Deserialize<IEnumerable<Game>>(File.ReadAllText("Games.json"))
                    .ToDictionary(m => m.Name, m => m);
            }
        }



    }
}
