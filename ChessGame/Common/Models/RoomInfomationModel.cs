﻿namespace Common.Models
{
    public class RoomInfomationModel
    {
        public int RoomId { get; set; }
        public int GameId { get; set; }
        public int Count 
        {
            get
            {
                if (FirstPlayer != null && SecondPlayer != null)
                    return 2;
                if (FirstPlayer == null && SecondPlayer == null)
                    return 0;
                return 1;
            }        
        }
        public UserModel FirstPlayer { get; set; }
        public UserModel SecondPlayer { get; set; }
        public bool IsInGame { get; set; }
        public bool IsFriend { get; set; } = false;
        public bool FirstPlayerReady { get; set; } = false;
        public bool SecondPlayerReady { get; set; } = false;
    }
}
