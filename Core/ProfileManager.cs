using KeyMaster.Models;
using System.Collections.Generic;
using System.Linq;

namespace KeyMaster.Core
{
    public class ProfileManager
    {
        private readonly ProfileStorage _storage;

        public List<Profile> Profiles { get; private set; }

        public Profile ActiveProfile { get; private set; }

        public ProfileManager()
        {
            _storage = new ProfileStorage();

            Profiles = new List<Profile>();

            LoadProfiles();
        }

        private void LoadProfiles()
        {
            List<Profile> loadedProfiles = _storage.LoadAllProfiles();

            if (loadedProfiles.Count == 0)
            {
                Profile global = new Profile
                {
                    Name = "Global"
                };

                Profiles.Add(global);

                ActiveProfile = global;

                _storage.SaveProfile(global);

                return;
            }

            Profiles.AddRange(loadedProfiles);

            Settings settings = _storage.LoadSettings();

            Profile activeProfile = null;

            if (settings != null &&
                !string.IsNullOrWhiteSpace(settings.ActiveProfile))
            {
                activeProfile =
                    Profiles.FirstOrDefault(
                        p => !string.IsNullOrWhiteSpace(p.Name) &&
                             p.Name.Equals(
                                 settings.ActiveProfile,
                                 System.StringComparison.OrdinalIgnoreCase));
            }

            if (activeProfile != null)
            {
                ActiveProfile = activeProfile;
            }
            else
            {
                ActiveProfile = Profiles[0];
            }
        }

        public void SetActiveProfile(Profile profile)
        {
            if (profile == null)
                return;

            if (!Profiles.Contains(profile))
                return;

            ActiveProfile = profile;
        }

        public void SaveActiveProfileSetting()
        {
            if (ActiveProfile == null)
                return;

            Settings settings = new Settings
            {
                ActiveProfile = ActiveProfile.Name
            };

            _storage.SaveSettings(settings);
        }

        public void SaveProfile(Profile profile)
        {
            if (profile == null)
                return;

            _storage.SaveProfile(profile);
        }

        public void SaveAllProfiles()
        {
            foreach (Profile profile in Profiles)
            {
                _storage.SaveProfile(profile);
            }
        }

        public void DeleteProfile(Profile profile)
        {
            if (profile == null)
                return;

            if (!Profiles.Contains(profile))
                return;

            if (Profiles.Count <= 1)
                return;

            _storage.DeleteProfile(profile);

            Profiles.Remove(profile);

            if (ActiveProfile == profile)
            {
                Profile globalProfile =
                    Profiles.FirstOrDefault(
                        p => !string.IsNullOrWhiteSpace(p.Name) &&
                             p.Name.Equals(
                                 "Global",
                                 System.StringComparison.OrdinalIgnoreCase));

                if (globalProfile != null)
                {
                    ActiveProfile = globalProfile;
                }
                else
                {
                    ActiveProfile = Profiles[0];
                }
            }
        }

        public bool RenameProfile(Profile profile, string newName)
        {
            if (profile == null)
                return false;

            if (!Profiles.Contains(profile))
                return false;

            if (string.IsNullOrWhiteSpace(newName))
                return false;

            newName = newName.Trim();

            foreach (Profile existingProfile in Profiles)
            {
                if (existingProfile == profile)
                    continue;

                if (existingProfile.Name.Equals(
                    newName,
                    System.StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            string oldName = profile.Name;

            profile.Name = newName;

            _storage.DeleteProfileByName(oldName);

            _storage.SaveProfile(profile);

            return true;
        }

        public bool ImportProfile(Profile profile)
        {
            if (profile == null)
                return false;

            if (string.IsNullOrWhiteSpace(profile.Name))
                return false;

            profile.Name = profile.Name.Trim();

            foreach (Profile existingProfile in Profiles)
            {
                if (existingProfile.Name.Equals(
                    profile.Name,
                    System.StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            Profiles.Add(profile);

            _storage.SaveProfile(profile);

            SetActiveProfile(profile);

            SaveActiveProfileSetting();

            return true;
        }

        public int ImportAllProfiles(ProfilePackage package, List<string> skippedProfiles, List<string> importedProfiles)
        {
            if (package == null)
                return 0;

            if (package.FormatVersion != 1)
                return 0;

            if (package.Profiles == null)
                return 0;

            int importedCount = 0;

            foreach (Profile profile in package.Profiles)
            {
                if (profile == null)
                    continue;

                if (string.IsNullOrWhiteSpace(profile.Name))
                    continue;

                profile.Name = profile.Name.Trim();

                bool exists =
                    Profiles.Any(
                        existingProfile =>
                            existingProfile.Name.Equals(
                                profile.Name,
                                System.StringComparison.OrdinalIgnoreCase));

                if (exists)
                {
                    if (skippedProfiles != null)
                        skippedProfiles.Add(profile.Name);

                    continue;
                }

                Profiles.Add(profile);

                _storage.SaveProfile(profile);

                if (importedProfiles != null)
                    importedProfiles.Add(profile.Name);

                importedCount++;
            }

            return importedCount;
        }

        public string ActiveProfileName
        {
            get
            {
                return ActiveProfile != null
                    ? ActiveProfile.Name
                    : null;
            }
        }
    }
}