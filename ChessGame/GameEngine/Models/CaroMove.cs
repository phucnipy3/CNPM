using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models
{
    public class CaroMove: IGameMove
    {
        public CaroChessman Chessman { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool GameEnded { get; set; } = false;

    }
}
