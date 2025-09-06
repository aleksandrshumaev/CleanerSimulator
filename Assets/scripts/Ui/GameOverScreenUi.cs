using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenUi : Button
{
    [SerializeField] GlobalParameters _globalParameters;
    [SerializeField] Text _moneyRecieved;
    [SerializeField] Text _smashedText;
    [SerializeField] Text _watchAddAndContinueButton;
    [SerializeField] Text _goHomeButton;
    [SerializeField] Text _pressMeButton;
    int _moneyToGet;

    public GlobalParameters GlobalParameters { get => _globalParameters; set => _globalParameters = value; }
    void Start()
    {
        //base.Start();
        _smashedText.text = PlayerStats.Localization.GetLocalizationFor("SmashedText");
        _watchAddAndContinueButton.text = PlayerStats.Localization.GetLocalizationFor("WatchAddAndContinueButton");
        _goHomeButton.text = PlayerStats.Localization.GetLocalizationFor("GoHomeButton");
        _pressMeButton.text = PlayerStats.Localization.GetLocalizationFor("PressMeButton");
    }
    public void OnContinoueButton()
    {
        OnBottonClick();
        //Debug.Log("Watching add");
        PlayerStats.Advertisment.WatchAdToContinue();
        GlobalParameters.ContinueGame();
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
    public void OnHomeButton()
    {
        OnBottonClick();
        SceneManager.LoadScene(1);
        //Debug.Log("Change Scene to home");
        GlobalParameters.PlayerInteractions.PlayerStats.Money += _moneyToGet;
    }
    public void OnPressMeButton()
    {
        GlobalParameters.PlayerInteractions.PlayerStats.Audio.Play("Fart", false);
        //Debug.Log("Fart");
    }
    private void OnEnable()
    {
        _moneyToGet = GlobalParameters.PlayerInteractions.PlayerStats.RevenuForMission * (DateTime.Compare(GlobalParameters.PlayerInteractions.PlayerStats.Time, DateTime.Now) >= 0 ? 2 : 1);
        _moneyRecieved.text = "+" + _moneyToGet.ToString() + "$";
    }
}
