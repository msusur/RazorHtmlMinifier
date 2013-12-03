﻿using System;
using System.Configuration;

namespace MinifierLibrary.Helpers
{
    internal class MinifierConfiguration : ConfigurationSection
    {
        private static readonly Lazy<MinifierConfiguration> InstanceTrunk = new Lazy<MinifierConfiguration>(CreateConfiguration, true);

        private static MinifierConfiguration CreateConfiguration()
        {
            return (MinifierConfiguration)ConfigurationManager.GetSection("minifier");
        }

        public static MinifierConfiguration Instance
        {
            get { return InstanceTrunk.Value; }
        }

        [ConfigurationProperty("minifyPages", DefaultValue = true, IsRequired = false)]
        public bool MinifyPages
        {
            get { return (bool)this["minifyPages"]; }
            set { this["minifyPages"] = value; }
        }

        [ConfigurationProperty("type", DefaultValue = "default", IsRequired = false)]
        [StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 20)]
        public string ConfigurationType
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }
    }
}
