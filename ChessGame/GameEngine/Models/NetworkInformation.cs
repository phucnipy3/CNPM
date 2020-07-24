using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models
{
    public class NetworkInformation
    {
        public Move Move { get; set; }
        public bool SenderWin { get; set; } = false;
        public bool? FirstMove { get; set; }

    }

    public class Move
    {
        /// <summary>
        /// Horizontal
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Vertical
        /// </summary>
        public int Y { get; set; }
        public CaroChessman CaroChessman { get; set; }
    }
}
