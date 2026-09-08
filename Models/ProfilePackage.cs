using System.Collections.Generic;

namespace KeyMaster.Models
{
    public class ProfilePackage
    {
        public int FormatVersion { get; set; }

        public List<Profile> Profiles { get; set; }

        public ProfilePackage()
        {
            Profiles = new List<Profile>();
        }
    }
}