using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EddyLib.Util.DrawerAttributes
{

public class ElementTitleAttribute : PropertyAttribute
{
    public string Varname;
    public ElementTitleAttribute(string ElementTitleVar)
    {
        Varname = ElementTitleVar;
    }
}

}
