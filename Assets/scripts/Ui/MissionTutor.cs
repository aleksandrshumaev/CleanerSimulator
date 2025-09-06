using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionTutor : TutorPage
{
    [SerializeField] Text _speedUpText;
    [SerializeField] Text _cleanSpeedUpText;
    [SerializeField] Text _revenuUpText;
    [SerializeField] Text _passText;
    [SerializeField] Text _megaphoneText;
    [SerializeField] Text _heartText;
    GlobalParameters _globalParameters;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerStats.HasReadMissionTutor)
        {
            _globalParameters = GameObject.Find("GlobalParametrs").GetComponent<GlobalParameters>();
            //_globalParameters.IsGameRun = false;
            TutorPanel.SetActive(true);
            TutorText.text = PlayerStats.Localization.GetLocalizationFor("WorkTutor");
            _speedUpText.text = PlayerStats.Localization.GetLocalizationFor("SpeedUpTutor");
            _cleanSpeedUpText.text = PlayerStats.Localization.GetLocalizationFor("CleanSpeedUpTutor");
            _revenuUpText.text = PlayerStats.Localization.GetLocalizationFor("RevenuTutor");
            _passText.text = PlayerStats.Localization.GetLocalizationFor("PassTutor");
            _megaphoneText.text = PlayerStats.Localization.GetLocalizationFor("MegaphoneTutor");
            _heartText.text = PlayerStats.Localization.GetLocalizationFor("HeartTutor");
        }
    }
    public override void OnTutorButton()
    {
        base.OnTutorButton();
        PlayerStats.HasReadMissionTutor = true;
       _globalParameters.IsGameRun = true;
    }
}
