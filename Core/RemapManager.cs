using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KeyMaster.Models;

namespace KeyMaster.Core
{
    public class RemapManager
    {
        private readonly List<RemapRule> _rules;

        public RemapManager()
        {
            _rules = new List<RemapRule>();
        }

        public IReadOnlyList<RemapRule> Rules => _rules;

        public void AddRule(Keys source, Keys target)
        {
            RemoveRule(source);

            _rules.Add(
                new RemapRule(source, target));
        }

        public void RemoveRule(Keys source)
        {
            RemapRule existingRule =
                _rules.FirstOrDefault(x => x.Source == source);

            if (existingRule != null)
            {
                _rules.Remove(existingRule);
            }
        }

        public bool TryGetTarget(
            Keys source,
            out Keys target)
        {
            RemapRule rule =
                _rules.FirstOrDefault(
                    x => x.Source == source &&
                         x.Enabled);

            if (rule != null)
            {
                target = rule.Target;
                return true;
            }

            target = Keys.None;

            return false;
        }
    }
}