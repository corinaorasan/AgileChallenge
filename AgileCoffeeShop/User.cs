namespace AgileCoffeeShop
{
    public class User
    {
        public Coordinate Coordinate { get; private set; }
        public User(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
    }
}
