
namespace Core
{
    public struct Location
    {
        private readonly double _lat;
        private readonly double _lon;

        public Location(double latitude, double longitude)
        {
            _lat = latitude;
            _lon = longitude;
        }

        public double Latitude
        {
            get { return _lat; }
        }

        public double Longitude
        {
            get { return _lon; }
        }
    }

}
