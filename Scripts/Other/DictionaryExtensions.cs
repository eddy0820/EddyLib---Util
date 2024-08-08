using System.Collections.Generic;

namespace EddyLib.Util
{

public static class DictionaryExtensions
{
    public static void CarefulAdd<T, U>(this Dictionary<T, List<U>> dict, T key, U value)
    {
        if(!dict.ContainsKey(key))
            dict.Add(key, new List<U>());

        dict[key].Add(value);
    }

    public static void CarefulClear<T, U>(this Dictionary<T, List<U>> dict, T key)
    {
        if(dict.ContainsKey(key))
            dict[key].Clear();
    }

    public static bool CarefulContains<T, U>(this Dictionary<T, List<U>> dict, T key, U value)
    {
        if(!dict.ContainsKey(key))
            return false;
        return dict[key].Contains(value); 
    }

    public static void CarefulRemove<T, U>(this Dictionary<T, List<U>> dict, T key, U value)
    {
        if(!dict.ContainsKey(key))
            return;

        dict[key].Remove(value);
    }
}

}
