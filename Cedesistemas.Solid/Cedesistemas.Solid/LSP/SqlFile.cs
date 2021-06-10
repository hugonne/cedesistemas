using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedesistemas.Solid.LSP
{
    public class SqlFile
    {
        public string FilePath { get; set; }

        public string FileText { get; set; }

        public string LoadText()
        {
            //
            return "";
        }

        public virtual string SaveText()
        {
            //
            return "";
        }
    }
}
