namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            if (line == null)
            {
                return null;
            }

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogWarning("Not enough data to parse.");
                return null;
            }


            double latitude;
            double longitude;
            try
            {
                latitude = double.Parse(cells[0]);
                longitude = double.Parse(cells[1]);

            }
            catch (System.Exception ex)
            {
                return null;
            }
            string name = cells[2];
            if (name.Length == 0)
            {
                return null;
            }

            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = name;
            Point location = new Point();
            location.Latitude = latitude;
            location.Longitude = longitude;

            tacoBell.Location = location;

            return tacoBell;
        }
    }
}