using System;
using System.Collections.Generic;
using MinifierLibrary.Exceptions;
using MinifierLibrary.Helpers;

namespace MinifierLibrary.Minifiers
{
    internal class MinifierFactory
    {
        private static readonly Dictionary<string, Type> Minifiers = new Dictionary<string, Type>
                                                                         {
                                                                             { "default", typeof(DefaultMinifier) },
                                                                         };

        public static IMinifier GetMinifier()
        {
            var key = MinifierConfiguration.Instance.ConfigurationType;
            var minifierType = Minifiers[key];
            if (minifierType == null)
            {
                throw new MinifierTypeNotFoundException(key);
            }
            try
            {
                var resultMinifier = (IMinifier)Activator.CreateInstance(minifierType);
                return resultMinifier;
            }
            catch (Exception ex)
            {
                throw new MinifierTypeNotFoundException(key, ex);
            }
        }

        public static void AddMinifier<TMinifier>(string key, TMinifier minifier)
            where TMinifier : IMinifier
        {
            Minifiers[key.ToLowerInvariant()] = minifier.GetType();
        }
    }
}