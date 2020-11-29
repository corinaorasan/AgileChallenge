namespace AgileCoffeeShop
{
    public class User
    {
        #region Members
        public Coordinate Coordinate { get; set; }
        #endregion

        public User()
        {
            Coordinate.XCoordinate= 0;
            Coordinate.YCoordinate = 0;
        }
    }
}
