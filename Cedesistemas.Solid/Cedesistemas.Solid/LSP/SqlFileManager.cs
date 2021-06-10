using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedesistemas.Solid.LSP
{
    public class SqlFileManager
    {
        public List<SqlFile> SqlFiles { get; set;  }

        public string GetTextFromFiles()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var file in SqlFiles)
            {
                stringBuilder.Append(file.LoadText());
            }
            return stringBuilder.ToString();
        }

        public void SaveTextIntoFiles()
        {
            foreach (var file in SqlFiles)
            {
                file.SaveText();
            }
        }
    }
}
