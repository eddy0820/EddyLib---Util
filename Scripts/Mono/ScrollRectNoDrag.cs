using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EddyLib.Util.Mono
{

public class ScrollRectNoDrag : ScrollRect
{
    public override void OnDrag(PointerEventData eventData) {}
}

}
