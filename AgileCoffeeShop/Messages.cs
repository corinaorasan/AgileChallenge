namespace AgileCoffeeShop
{
    public static class Messages
    { 
        public static string InvalidURLMessage
        {
            get
            {
                return "Invalid URL. Program will exit.\n Press any key to continue...";
            }
        }
        public static string InvalidCoordinateMessage(string coordinateName)
        {
            var message = $"Invalid value for {coordinateName} coordinate. Program will exit.\nPress any key to continue...";
            return message;
        }

        public static string InvalidCoordinatesException(string exceptionMessage)
        {
            var message = $"Invalid coordinates. {exceptionMessage} Program will exit.\nPress any key to continue...";
            return message;
        }
        public static string InvalidURLException(string exceptionMessage)
        {
            var message = $"Invalid URL. {exceptionMessage} Program will exit.\nPress any key to continue...";
            return message;
        }

    }
}
