using System.Collections.Generic;
using KeyMaster.Models;

namespace KeyMaster.Core
{
    public class ProfileManager
    {
        public List<Profile> Profiles { get; private set; }

        public Profile ActiveProfile { get; private set; }

        public ProfileManager()
        {
            Profiles = new List<Profile>();

            Profile global = new Profile
            {
                Name = "Global"
            };

            Profiles.Add(global);

            ActiveProfile = global;
        }

        public void SetActiveProfile(Profile profile)
        {
            if (profile == null)
                return;

            if (!Profiles.Contains(profile))
                return;

            ActiveProfile = profile;
        }
    }
}