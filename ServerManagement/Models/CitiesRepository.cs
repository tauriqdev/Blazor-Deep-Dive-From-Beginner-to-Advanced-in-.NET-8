namespace ServerManagement.Models
{
    public static class CitiesRepository
    {
        private static readonly List<string> _cities =
        [
            "Toronto",
            "Montreal",
            "Ottawa",
            "Calgary",
            "Halifax",
        ];

        public static List<string> GetCities() => _cities;
    }
}
