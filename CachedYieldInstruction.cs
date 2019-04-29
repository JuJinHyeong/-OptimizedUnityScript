using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CachedYieldInstruction{
    class FloatComparer : IEqualityComparer<float>
    {
        bool IEqualityComparer<float>.Equals(float x, float y)
        {
            return x == y;
        }
        int IEqualityComparer<float>.GetHashCode(float obj)
        {
            return obj.GetHashCode();
        }
    }
    public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
    public static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();

    private static Dictionary<float, WaitForSeconds> cachedWaitForSeconds = new Dictionary<float, WaitForSeconds>(new FloatComparer());
    
    public static WaitForSeconds WaitForSeconds(float seconds){
        WaitForSeconds cached;
        if(!cachedWaitForSeconds.ContainsKey(seconds)){
            cachedWaitForSeconds.Add(seconds, cached = new WaitForSeconds(seconds));
        }
        else{
            cached = cachedWaitForSeconds[seconds];
        }
        return cached;
    }
}