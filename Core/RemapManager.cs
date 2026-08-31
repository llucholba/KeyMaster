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

        public IReadOnlyList<RemapRule> Rules
        {
            get { return _rules.AsReadOnly(); }
        }

        public bool AddRule(Keys source, Keys target)
        {
            if (source == Keys.None || target == Keys.None)
                return false;

            // Evitamos F1 -> F1
            if (source == target)
                return false;

            // Si ya existe un remapeo para esa tecla,
            // lo reemplazamos.
            RemoveRule(source);

            _rules.Add(
                new RemapRule(source, target));

            return true;
        }

        public bool RemoveRule(Keys source)
        {
            RemapRule existingRule =
                _rules.FirstOrDefault(
                    x => x.Source == source);

            if (existingRule == null)
                return false;

            _rules.Remove(existingRule);

            return true;
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