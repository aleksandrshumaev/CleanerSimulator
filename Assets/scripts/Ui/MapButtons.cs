using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButtons : Button
{


    public void OnHomeButton()
    {
        OnBottonClick();
        SceneManager.LoadScene(1);
    }
    public void OnWorkButton()
    {
        OnBottonClick();
        SceneManager.LoadScene(2);
    }
    public void OnAddButton()
    {
        OnBottonClick();
        PlayerStats.Time = PlayerStats.Advertisment.WatchAdToIncreaseRevenu();
        Debug.Log(PlayerStats.Time.ToString());
    }

}
