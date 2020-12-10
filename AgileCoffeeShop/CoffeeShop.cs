namespace AgileCoffeeShop
{
    public class CoffeeShop
    {
        #region Members
        public string Name { get;  private set; }
        public Coordinate Coordinate { get; private set; }
        #endregion

        public CoffeeShop (string name, Coordinate coordinate)
        {
            Name = name;
            Coordinate = coordinate;
        }
    }
}
