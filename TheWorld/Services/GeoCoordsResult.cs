namespace TheWorld.Services
{
    public class GeoCoordsResult
    {
        public bool Success { get; set; }       // Whether it was successful or not
        public string Message { get; set; }     // String for any messages we need to relay
        public double Longitude { get; set; }   // Location
        public double Latitude { get; set; }    // Location
    }
}