namespace AgileCoffeeShop
{
    public class CoffeeShop
    {
        #region Members
        public string Name { get; set; }
        public Coordinate Coordinate { get; set; }
        #endregion

        public CoffeeShop ()
        {
            Name = string.Empty;
            Coordinate.XCoordinate = 0;
            Coordinate.YCoordinate = 0;
        }
    }
}
