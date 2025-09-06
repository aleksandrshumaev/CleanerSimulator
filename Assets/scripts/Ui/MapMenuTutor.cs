using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMenuTutor : TutorPage
{
    [SerializeField] GameObject _arrowToAd;
    [SerializeField] GameObject _arrowToHome;
    [SerializeField] GameObject _arrowToWork;
    int _tutorState;
    // Start is called before the first frame update
    private void Start()
    {
        if (!PlayerStats.HasReadMapTutor)
        {
            _tutorState = 0;
            TutorPanel.SetActive(true);
            _arrowToAd.SetActive(true);
            TutorText.text = PlayerStats.Localization.GetLocalizationFor("FirstMenuTutorText");

        }
    }
    public void NextTutorChange()
    {
        ArrowDisable();
        _tutorState++;
        if (_tutorState == 1)
        {
            TutorText.text = PlayerStats.Localization.GetLocalizationFor("SecondMenuTutorText");
            _arrowToHome.SetActive(true);
        }
        else if (_tutorState == 2)
        {
            TutorText.text = PlayerStats.Localization.GetLocalizationFor("ThirdMenuTutorText");
            _arrowToWork.SetActive(true);
        }
        else
        {
            PlayerStats.HasReadMapTutor = true;
            TutorPanel.SetActive(false);
        }
    }
    void ArrowDisable()
    {
        _arrowToAd.SetActive(false);
        _arrowToHome.SetActive(false);
        _arrowToWork.SetActive(false);
    }
}
