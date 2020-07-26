namespace Common.Enums
{
    public enum CaroChessman
    {
        /// <summary>
        /// Default value, need to be 0
        /// </summary>
        Empty = 0,
        X = 1,
        O = -1,
    }
    public static class CaroChessmanExtension
    {
        public static CaroChessman OppositeChessman(this CaroChessman chessman)
        {
            if (chessman == CaroChessman.X)
                return CaroChessman.O;
            if (chessman == CaroChessman.O)
                return CaroChessman.X;
            return CaroChessman.Empty;
        }
    } 
}
