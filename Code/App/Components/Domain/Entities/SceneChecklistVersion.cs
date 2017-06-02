using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class SceneChecklistVersion : SceneVersionBase
    {
        public override string File
        {
            get
            {
                return Lib.CommonFuncs.FileNameWithExtension(base.Code, Lib.Constants.FileExtensions.SceneChecklistVersion);
            }
        }
    }
}
