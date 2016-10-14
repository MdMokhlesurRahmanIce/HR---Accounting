using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ST
{
    public enum ImageSaveOption
    {
        Temporary,
        Permanent
    }
    public enum ConsumptionSource
    {
        PreCosting,
        StyleDetail
    }

    public enum FormClearOptions
    {
        ClearAll,
        ClearTextBoxOnly,
        ClearDropdownsOnly,
        ClearTextBoxAndDropdownOnly,
        ClearTextBoxAndDropdownAndCheckBoxOnly,
        ClearAllInThisParentContainer
    }

}
