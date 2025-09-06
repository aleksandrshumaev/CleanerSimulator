using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeMenuTutor : TutorPage
{

    void Start()
    {
        if (!PlayerStats.HasReadHomeTutor)
        {
            TutorPanel.SetActive(true);
            TutorText.text = PlayerStats.Localization.GetLocalizationFor("HomeTutor");
        }
    }
    public override void OnTutorButton()
    {
        base.OnTutorButton();
        PlayerStats.HasReadHomeTutor = true;
    }
}
