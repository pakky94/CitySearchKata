namespace SearchKata
{
    public interface ICityFinder
    {
        IEnumerable<string> Find(string search);
    }
}