using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CachedYieldInstruction{
    public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
    public static readonly WaitForUpdate WaitForFixedUpdate = new WaitForFixedUpdate();

    private Dictionary<float, WaitForSeconds> cachedWaitForSeconds = new Dictionary<float, WaitForSeconds>();
    
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