using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


namespace ArduinoLib
{
    public class ArduOptions
    {

        public Dictionary<string, object> Options { get; }

        private readonly HashSet<string> _availableOptions = new HashSet<string>();

        public ArduOptions(Dictionary<string, object> options)
        {
            Options = options ??
                throw new ArgumentException("Error: options are required for communicating with board.");

            var availableOptions = GetAvailableOptions();

            if (Options.Any(values => !availableOptions.Contains(values.Key)))
            {
                throw new ArgumentException(string.Format("Error: available options are {0}. ", availableOptions.ToList()));
            }

            if (Options.Any(values => values.Value == null))
            {
                throw new ArgumentException("Cannot have null values for options.");
            }


        }

        private static string[] GetAvailableOptions()
        {

            const string resourceName = "ArduinoLib.Resources.available_options";
            var assembly = Assembly.GetExecutingAssembly();
            string[] availableOptions;

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                availableOptions = result.Split(new char[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            }

            return availableOptions;
        }

    }
}
