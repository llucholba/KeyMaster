using KeyMaster.Core;

namespace KeyMaster.Models
{
    public class RemapListItem
    {
        public RemapRule Rule { get; }

        public RemapListItem(RemapRule rule)
        {
            Rule = rule;
        }

        public override string ToString()
        {
            return string.Format(
                "{0} → {1}",
                KeyCatalog.GetDisplayName(Rule.Source),
                KeyCatalog.GetDisplayName(Rule.Target));
        }
    }
}