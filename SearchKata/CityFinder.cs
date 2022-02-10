namespace SearchKata
{
    public class CityFinder : ICityFinder
    {
        private readonly IDb _db;

        public CityFinder(IDb db)
        {
            _db = db;
        }

        public IEnumerable<string> Find(string searchTerm)
        {
            if (searchTerm.Equals("*"))
                return _db.CityNames.AsEnumerable();

            if (searchTerm.Length < 2)
                return Enumerable.Empty<string>();

            return _db.CityNames.Where(c => c.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
    }
}