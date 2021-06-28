using System;
using System.Text;

namespace GeneratoryParser.Utils
{
    public class JsonReader
    {
        private string _path;
        
        public JsonReader(string path)
        {
            this._path = path;
        }

        public string readFile()
        {
            var result = System.IO.File.ReadAllText(_path, Encoding.UTF8);
            return result;
        }
        
        
    }
}