using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CookieCookbook
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Instructions { get; set; }
        
    }
    
    public class StoreRecipesInFile
    {
        public StoreRecipesInFile() { }

        const string FileName = "Recipe";
        const FileFormat FileFormat = FileFormat.Json;
    }
}
