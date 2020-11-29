namespace AgileCoffeeShop
{
    public class User
    {
        #region Members
        public Coordinate Coordinate { get; set; }
        #endregion

        public User()
        {
            Coordinate = new Coordinate(); 
        }
    }
}
