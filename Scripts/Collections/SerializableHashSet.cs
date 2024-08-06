using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace EddyLib.Util.Collections
{

[System.Serializable]
public class SerializableHashSet<T> : ISerializationCallbackReceiver
{
    [ReadOnly, SerializeField] List<T> _list = new();
    public HashSet<T> Value = new();

    public void OnBeforeSerialize()
    {
        _list.Clear();
        foreach(T entry in Value)
        {
            _list.Add(entry);
        }
    }

    public void OnAfterDeserialize() {}
}

}
