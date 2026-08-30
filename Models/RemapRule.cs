using System.Windows.Forms;

namespace KeyMaster.Models
{
    public class RemapRule
    {
        public Keys Source { get; set; }

        public Keys Target { get; set; }

        public bool Enabled { get; set; } = true;

        public RemapRule()
        {
        }

        public RemapRule(Keys source, Keys target)
        {
            Source = source;
            Target = target;
        }

        public override string ToString()
        {
            return $"{Source} → {Target}";
        }
    }
}
