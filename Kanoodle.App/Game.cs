using Kanoodle.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanoodle.App
{
    public class Game
    {
        public string Name { get; set; }
        public IEnumerable<Piece> State { get; set; }
        public IEnumerable<Piece> Solution { get; set; }
    }
}
