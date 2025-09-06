using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Advertisments : MonoBehaviour
{
    private void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4376009", false);
        }
    }
    public void WatchAdToContinue()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("Rewarded_Android");
        }
    }
    public DateTime WatchAdToIncreaseRevenu()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("Rewarded_Android");
        }
        DateTime time = DateTime.Now;
        time=time.AddHours(2);
        return time;
    }
}
