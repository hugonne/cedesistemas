using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedesistemas.Solid.LSP
{
    public class ReadOnlySqlFile : SqlFile
    {
        public string FilePath { get; set; }

        public string FileText { get; set; }

        public string LoadText()
        {
            //
            return "";
        }
        public override string SaveText()
        {
            /* Throw an exception when app flow tries to do save. */
            throw new Exception("Can't Save");
        }
    }
}
