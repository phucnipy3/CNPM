using Common.Enums;

namespace Common.Models
{
    public class CaroMove : IGameMove
    {
        public CaroChessman Chessman { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool GameEnded { get; set; } = false;

    }
}
