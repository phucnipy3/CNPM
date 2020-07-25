namespace Common.Models
{
    public class RoomRequestModel
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int RoomId { get; set; }
        public string Search { get; set; }
    }
}
