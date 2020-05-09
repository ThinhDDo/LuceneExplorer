using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuceneExplorer.models
{
    public class FileType
    {
        public FileType(string tenType, bool isuse)
        {
            this.TenType = tenType;
            this.IsUse = isuse;
        }

        public string TenType { get; set; } = "";
        public bool IsUse { get; set; } = false;

        public override string ToString()
        {
            return "[" + TenType + "," + IsUse + "]";
        }
    }
}
