using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUpScreenSwitch :Button
{
    [SerializeField] GameObject _statsUpScreen;
    [SerializeField] GameObject _powerUpsScreen;
    [SerializeField] GameObject _backPower;

    [SerializeField] Text _switchToPowerUpPanellButton;
    [SerializeField] Text _switchToStatsPanellButton;
    [SerializeField] Text _powerUpPnaelDescription;
    [SerializeField] Text _statsPanelDescription;
    [SerializeField] Text _backButton;
    void Start()
    {

        _switchToPowerUpPanellButton.text = PlayerStats.Localization.GetLocalizationFor("SwitchToPowerUpPanellButton");
        _switchToStatsPanellButton.text = PlayerStats.Localization.GetLocalizationFor("SwitchToStatsPanellButton");
        _powerUpPnaelDescription.text = PlayerStats.Localization.GetLocalizationFor("PowerUpPnaelDescription");
        _statsPanelDescription.text = PlayerStats.Localization.GetLocalizationFor("StatsPanelDescription");
        _backButton.text = PlayerStats.Localization.GetLocalizationFor("BackButton");
    }
    public void SwitchToPowerUpScreen()
    {
        OnBottonClick();
        _statsUpScreen.SetActive(false);
        _powerUpsScreen.SetActive(true);
    }
    public void SwitchToStatsUpScreen()
    {
        OnBottonClick();
        _statsUpScreen.SetActive(true);
        _powerUpsScreen.SetActive(false);
    }
    public void OnBackButton()
    {
        OnBottonClick();
        SceneManager.LoadScene(0);
    }

}
