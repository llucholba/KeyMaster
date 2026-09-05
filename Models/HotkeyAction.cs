using System.Collections.Generic;
using System.Windows.Forms;

namespace KeyMaster.Models
{
    public class HotkeyAction
    {
        public List<Keys> Keys { get; set; }

        public string Action { get; set; }

        public string Configuration { get; set; }

        public bool Enabled { get; set; }

        public HotkeyAction()
        {
            Keys = new List<Keys>();
            Enabled = true;
        }
    }
}