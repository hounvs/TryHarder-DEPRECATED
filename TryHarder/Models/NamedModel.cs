namespace TryHarder.Models
{
    public class NamedModel
    {
        internal static string DefaultName = string.Empty;
        internal static int DefaultID = -1;

        public string Name;

        public int ID;

        public NamedModel()
        {
            Name = DefaultName;
            ID = DefaultID;
        }
    }
}