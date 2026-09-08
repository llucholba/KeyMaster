using KeyMaster.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace KeyMaster.Core
{
    public class ProfileStorage
    {
        private readonly string _profilesFolder;
        private readonly string _settingsFile;

        public ProfileStorage()
        {
            string appData =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData);

            _profilesFolder =
                Path.Combine(
                    appData,
                    "KeyMaster",
                    "Profiles");

            Directory.CreateDirectory(_profilesFolder);

            _settingsFile =
                Path.Combine(
                    _profilesFolder,
                    "Settings.json");
        }

        public string ProfilesFolder
        {
            get { return _profilesFolder; }
        }

        public void SaveSettings(Settings settings)
        {
            if (settings == null)
                return;

            var serializer =
                new JavaScriptSerializer();

            string json = serializer.Serialize(settings);

            File.WriteAllText(
                _settingsFile,
                json,
                Encoding.UTF8);
        }
        public Settings LoadSettings()
        {
            if (!File.Exists(_settingsFile))
                return null;

            try
            {
                string json =
                    File.ReadAllText(
                        _settingsFile,
                        Encoding.UTF8);

                var serializer = new JavaScriptSerializer();

                return serializer.Deserialize<Settings>(json);
            }
            catch
            {
                return null;
            }
        }

        public void SaveProfile(Profile profile)
        {
            if (profile == null)
                return;

            string fileName = MakeSafeFileName(profile.Name) + ".json";

            string filePath =
                Path.Combine(
                    _profilesFolder,
                    fileName);

            var serializer = new JavaScriptSerializer();

            string json = serializer.Serialize(profile);

            File.WriteAllText(
                filePath,
                json,
                Encoding.UTF8);
        }

        public Profile LoadProfile(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            try
            {
                string json =
                    File.ReadAllText(
                        filePath,
                        Encoding.UTF8);

                var serializer = new JavaScriptSerializer();

                return serializer.Deserialize<Profile>(json);
            }
            catch
            {
                return null;
            }
        }

        public List<Profile> LoadAllProfiles()
        {
            var profiles = new List<Profile>();

            if (!Directory.Exists(_profilesFolder))
                return profiles;

            string[] files =
                Directory.GetFiles(
                    _profilesFolder,
                    "*.json")
                .Where(file =>
                    !Path.GetFileName(file)
                        .Equals(
                            "Settings.json",
                            StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string file in files)
            {
                Profile profile = LoadProfile(file);

                if (profile != null)
                    profiles.Add(profile);
            }

            return profiles;
        }

        public void DeleteProfile(Profile profile)
        {
            if (profile == null)
                return;

            string fileName = MakeSafeFileName(profile.Name) + ".json";

            string filePath =
                Path.Combine(
                    _profilesFolder,
                    fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public void DeleteProfileByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            string fileName = MakeSafeFileName(name) + ".json";

            string filePath =
                Path.Combine(
                    _profilesFolder,
                    fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        private string MakeSafeFileName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Perfil";

            string result = name.Trim();

            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                result = result.Replace(invalidChar, '_');
            }

            return result;
        }
    }
}