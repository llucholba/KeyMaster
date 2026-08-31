using System.Windows.Forms;

namespace KeyMaster.Models
{
    public class KeyDefinition
    {
        public Keys Key { get; set; }

        public string DisplayName { get; set; }

        public KeyDefinition(Keys key, string displayName)
        {
            Key = key;
            DisplayName = displayName;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}