using System.Collections.Generic;

namespace KeyMaster.Models
{
    public class Profile
    {
        public string Name { get; set; }

        public List<RemapRule> Remaps { get; set; }

        public List<HotkeyAction> Hotkeys { get; set; }

        //public List<Script> Scripts { get; set; }

        public Profile()
        {
            Remaps = new List<RemapRule>();
            Hotkeys = new List<HotkeyAction>();
            //Scripts = new List<Script>();
        }
    }
}