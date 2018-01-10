using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MicroserviceDuplicator
{
    internal static class MicroserviceDuplicator
    {
        private static void Main(string[] args)
        {
            var source = args[0];
            var destination = args[1];
            var pattern = args[2].ToLower();
            var repl = args[3].ToLower();

            Directory.CreateDirectory(destination);

            var transformations = new Dictionary<string, string>
            {
                {pattern, repl},
                {pattern.FirstCharToUpper(), repl.FirstCharToUpper()}
            };

            var excludedDirectories = new HashSet<string>
            {
                ".vs",
                "bin",
                "obj"
            };

            var excludedExtensions = new HashSet<string>();

            foreach (var file in GetFiles(source, excludedDirectories, excludedExtensions))
            {
                var relative = GetRelativePath(source, file);
                relative = Transform(relative, transformations);

                if (Directory.Exists(file))
                {
                    Directory.CreateDirectory(Path.Combine(destination, relative));
                }
                else
                {
                    var content = File.ReadAllText(file);
                    var result = Transform(content, transformations);

                    File.AppendAllText(Path.Combine(destination, relative), result);
                }
            }

            Console.WriteLine("Done");
        }

        private static IEnumerable<string> GetFiles(string path, ISet<string> excludedDirectories, ISet<string> excludedExtensions, SearchOption searchOption = SearchOption.AllDirectories)
        {
            foreach (var file in Directory.EnumerateFileSystemEntries(path, "*.*", searchOption))
            {

                var relative = GetRelativePath(path, file);

                var dirs = relative.Split('\\');

                if (excludedDirectories.Overlaps(dirs))
                {
                    continue;
                }

                if (excludedExtensions.Contains(Path.GetExtension(file)))
                {
                    continue;
                }

                yield return file;
            }
        }

        private static string GetRelativePath(string path, string file)
        {
            return file.Replace(path, "").TrimStart(new []{'\\'});
        }

        private static string Transform(string input, IDictionary<string, string> transformations)
        {
            var result = input;

            foreach (KeyValuePair<string, string> entry in transformations)
            {
                result = Regex.Replace(result, entry.Key, entry.Value);
            }

            return result;
        }

        private static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
