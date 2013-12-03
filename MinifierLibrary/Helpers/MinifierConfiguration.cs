using System;
using System.Configuration;

namespace MinifierLibrary.Helpers
{
    internal class MinifierConfiguration : ConfigurationSection
    {
        private static readonly Lazy<MinifierConfiguration> InstanceTrunk = new Lazy<MinifierConfiguration>(CreateConfiguration, true);

        private static MinifierConfiguration CreateConfiguration()
        {
            return (MinifierConfiguration)ConfigurationManager.GetSection("minifierConfiguration");
        }

        public static MinifierConfiguration Instance
        {
            get { return InstanceTrunk.Value; }
        }

        public bool MinifyPages
        {
            get { return (bool)this["minifyPages"]; }
            set { this["minifyPages"] = value; }
        }

        public string ConfigurationType
        {
            get { return (string)this["configurationType"]; }
            set { this["configurationType"] = value; }
        }
    }
}
