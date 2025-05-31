using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookieCookbook
{
    public interface IStringsRepository
    {
        List<string> Read(string filePath);
        void Write(string filePath, List<string> strings);
    }

    public class StringsTextualRepository : IStringsRepository
    {
        private static readonly string Separator = Environment.NewLine;

        public List<string> Read(string filePath)
        {
            if(File.Exists(filePath))
            {
                var fileContents = File.ReadAllText(filePath);
                return fileContents.Split(Separator).ToList();
            }
            return new List<string>();
        }

        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, string.Join(Separator, strings));
        }
    }

    public class StringsJsonRepository : IStringsRepository
    {
        private static readonly string Separator = Environment.NewLine;

        public List<string> Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileContents = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<string>>(fileContents);
            }
            return new List<string>();
        }

        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(strings));
        }
    }
}

