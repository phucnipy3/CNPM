namespace Common.Models
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public int GameId { get; set; }
        public int? FirstPlayerId { get; set; }
        public int? SecondPlayerId { get; set; }
    }
}
