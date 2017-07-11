namespace TryHarder.Models
{
    public class NamedModel
    {
        public static string DefaultName = string.Empty;
        public static int DefaultID = -1;

        private string name;
        private int id;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ProgrammaticName
        {
            get { return name.Replace(' ', '-').Replace('/','_'); }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public NamedModel()
        {
            Name = DefaultName;
            ID = DefaultID;
        }
    }
}