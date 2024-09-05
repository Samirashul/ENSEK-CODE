namespace ENSEK.Interfaces
{
    public interface iBaseAdapter
    {

        public bool CheckIfFieldExists(string table, string column, string id);
        public bool CheckIfEntryExists(string table, Dictionary<string, string> parameters);
    }
}
