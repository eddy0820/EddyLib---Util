using System;
using System.Collections.Generic;
using UnityEngine;

namespace EddyLib.Util.SmartAction
{

public class SmartAction
{
    Action action;
    readonly Dictionary<object, List<Action>> sources = new();

    readonly ESmartActionClearType clearType;
    readonly ESmartActionListenerType listenerType;

    public SmartAction(ESmartActionClearType _clearType = ESmartActionClearType.Manual, ESmartActionListenerType _listenerType = ESmartActionListenerType.Multiple)
    {
        clearType = _clearType;
        listenerType = _listenerType;
    }

    public void Subscribe(Action _action, object source)
    {
        switch(listenerType)
        {
            case ESmartActionListenerType.Multiple:
                action += _action;
                sources.CarefulAdd(source, _action);
                break;
            case ESmartActionListenerType.Single:
                action = _action;
                sources.CarefulAdd(source, _action);
                break;
            case ESmartActionListenerType.SingleWithSource:
                if(sources.ContainsKey(source))
                {
                    Debug.Log("Source already subscribed");
                    return;
                }
                sources.CarefulAdd(source, _action);
                action = _action;
                break;
        }
    }

    public void Unsubscribe(Action _action, object source)
    {
        switch(listenerType)
        {
            case ESmartActionListenerType.Multiple:
                action -= _action;
                sources.CarefulRemove(source, _action);
                break;
            case ESmartActionListenerType.Single:
                action = null;
                sources.CarefulRemove(source, _action);
                break;
            case ESmartActionListenerType.SingleWithSource:
                if(!sources.ContainsKey(source))
                {
                    Debug.Log("Source not subscribed");
                    return;
                }
                action = null;
                sources.CarefulRemove(source, _action);
                break;
        }
    }

    public void Invoke()
    {
        action?.Invoke();

        if(clearType is ESmartActionClearType.AfterInvoke)
        {
            action = null;
        }
    }
}

}
