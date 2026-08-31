using System.Windows.Forms;

namespace KeyMaster.Models
{
    public class KeyboardEvent
    {
        public Keys Key { get; set; }

        public int ScanCode { get; set; }

        public int Flags { get; set; }

        public bool IsKeyDown { get; set; }

        public bool IsInjected { get; set; }

        public KeyboardEvent(
            Keys key,
            int scanCode,
            int flags,
            bool isKeyDown,
            bool isInjected)
        {
            Key = key;
            ScanCode = scanCode;
            Flags = flags;
            IsKeyDown = isKeyDown;
            IsInjected = isInjected;
        }
    }
}