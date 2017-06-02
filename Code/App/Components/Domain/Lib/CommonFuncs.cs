using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Lib
{
    public static class CommonFuncs
    {
        public static string FileNameWithExtension(string fileName, string extension)
        {
           return string.Format("{0}.{1}", fileName, extension);
        }
    }
}
