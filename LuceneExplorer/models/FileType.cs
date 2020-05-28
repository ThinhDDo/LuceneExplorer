using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuceneExplorer.models
{
    public class FileType
    {

        public string TenType { get; set; } = "";
        public bool IsUse { get; set; } = false;

        public override string ToString()
        {
            return "[" + TenType + "," + IsUse + "]";
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType() == typeof(FileType))
            {
                FileType temp = (FileType)obj;
                return TenType.Equals(temp.TenType) && (IsUse == temp.IsUse);
            }
            return false;
        }
    }
}
