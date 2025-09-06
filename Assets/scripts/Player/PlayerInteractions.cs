using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] GameObject _powerUpUiObject;
    [SerializeField] GameObject _heartUiObject;
    [SerializeField] GameObject _moneyUiObject;
    [SerializeField] GameObject _gameOverScreen;
    GameOverScreenUi _gameOverScreenUi;
    SetTextUi _heartCountUi;
    SetTextUi _moneyCountUi;
    GlobalParameters _globalParameters;
    PlayerStats _playerStats;
    PowerUpUi _powerUpUi;

    public PlayerStats PlayerStats { get => _playerStats; set => _playerStats = value; }
    public GlobalParameters GlobalParameters { get => _globalParameters; set => _globalParameters = value; }

    // Start is called before the first frame update
    void Start()
    {
        _gameOverScreenUi = _gameOverScreen.GetComponent<GameOverScreenUi>();
        _powerUpUi = _powerUpUiObject.GetComponent<PowerUpUi>();
        PlayerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
        //GlobalParameters = PlayerStats.GlobalParameters;
        _heartCountUi = _heartUiObject.GetComponent<SetTextUi>();
        _moneyCountUi = _moneyUiObject.GetComponent<SetTextUi>();
        _moneyCountUi.SetText((10000000 + PlayerStats.RevenuForMission).ToString().Substring(1));
        _heartCountUi.SetText(PlayerStats.Hearts.ToString());
        _gameOverScreenUi.GlobalParameters = GlobalParameters;
        if(PlayerStats.Hearts==0)
        {
            ChangeHeart(PlayerStats.InitialHearts);
        }
        PlayerStats.CleanSpeed = PlayerStats.DefaultCleanSpeed*Mathf.Pow(PlayerStats.CleanSpeedUpPerLevel, PlayerStats.CleanSpeedStatLevel);
        PlayerStats.Speed = PlayerStats.DefaultSpeed;
        PlayerStats.RevenuForMission = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickUpSpeedUp(float time)
    {
        if (PlayerStats.IsSpeedUp)
            StopCoroutine("SpeedUpCountDownRoutin");
        StartCoroutine(SpeedUpCountDownRoutin(time));
        float speed = PlayerStats.DefaultSpeed * 2;
        PlayerStats.Speed = speed;
        PlayerStats.IsSpeedUp = true;
        _powerUpUi.SwitchSpeedUpIcon(true);
    }
    public void PickUpCleanSpeedUp(float time)
    {
        if (PlayerStats.IsCleanSpeedUp)
            StopCoroutine("CleanSpeedUpCountDownRoutin");
        StartCoroutine(CleanSpeedUpCountDownRoutin(time));
        PlayerStats.CleanSpeed = PlayerStats.DefaultCleanSpeed*2;
        PlayerStats.IsCleanSpeedUp = true;
        _powerUpUi.SwitchCleanSpeedUpIcon(true);
    }
    public void PickUpRevenuUp(float time)
    {
        if (PlayerStats.IsRevenuUp)
            StopCoroutine("RevenuUpCountDownRoutin");
        StartCoroutine(RevenuUpCountDownRoutin(time));
        PlayerStats.IsRevenuUp = true;
        _powerUpUi.SwitchRevenuUpIcon(true);
    }
    public void PickUpPass(float time)
    {
        if (PlayerStats.IsPass)
            StopCoroutine("PassCountDownRoutin");
        StartCoroutine(PassCountDownRoutin(time));
        PlayerStats.IsPass = true;
        _powerUpUi.SwitchPasIcon(true);
    }
    public void PickUpMegaphone(float time)
    {
        if (PlayerStats.IsMegaphone)
            StopCoroutine("MegaphoneDownRoutin");
        StartCoroutine(MegaphoneDownRoutin(time));
        GlobalParameters.IsMegaphonePicked = true;
        PlayerStats.IsMegaphone = true;
        _powerUpUi.SwitchMegaphoneIcon(true);
    }
    public void ChangeHeart(int heartAmount)
    {

        PlayerStats.Hearts = PlayerStats.Hearts + heartAmount;
        
        if(PlayerStats.Hearts==0)
        {
            GameOver();
        }
        _heartCountUi.SetText(PlayerStats.Hearts.ToString());
    }
    public void GetRevenu(int revenu)
    {
        if(revenu>0)
        {
            PlayerStats.Audio.Play("CoinPickUp",false);
            _playerStats.RevenuForMission =Mathf.FloorToInt(_playerStats.RevenuForMission + revenu*(Mathf.Pow(PlayerStats.CleanSpeedUpPerLevel,PlayerStats.RevenuStatLevel))*( _playerStats.IsRevenuUp ? 2 : 1));
            _moneyCountUi.SetText((10000000 + _playerStats.RevenuForMission).ToString().Substring(1));
            GlobalParameters.RestTime += 10;
        }
    }
    public void OffAllPowerUps()
    {
        PlayerStats.SetSpeedToDefault();
        PlayerStats.IsSpeedUp = false;
        _powerUpUi.SwitchSpeedUpIcon(false);
        PlayerStats.SetCleanSpeedToDefault();
        PlayerStats.IsCleanSpeedUp = false;
        _powerUpUi.SwitchCleanSpeedUpIcon(false);
        PlayerStats.IsRevenuUp = false;
        _powerUpUi.SwitchRevenuUpIcon(false);
        PlayerStats.IsPass = false;
        _powerUpUi.SwitchPasIcon(false);
        GlobalParameters.IsMegaphonePicked = false;
        PlayerStats.IsMegaphone = false;
        _powerUpUi.SwitchMegaphoneIcon(false);
    }
    public void GameOver()
    {
        GlobalParameters.IsGameRun = false;
        StopAllCoroutines();
        OffAllPowerUps();
        PlayerStats.Speed = 0;
        _gameOverScreen.SetActive(true);
        Debug.Log("GameOver");
    }
    IEnumerator SpeedUpCountDownRoutin(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        PlayerStats.SetSpeedToDefault();
        PlayerStats.IsSpeedUp = false;
        _powerUpUi.SwitchSpeedUpIcon(false);
    }
    IEnumerator CleanSpeedUpCountDownRoutin(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        PlayerStats.SetCleanSpeedToDefault();
        PlayerStats.IsCleanSpeedUp = false;
        _powerUpUi.SwitchCleanSpeedUpIcon(false);
    }
    IEnumerator RevenuUpCountDownRoutin(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        PlayerStats.IsRevenuUp = false;
         _powerUpUi.SwitchRevenuUpIcon(false);
    }
    IEnumerator PassCountDownRoutin(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        PlayerStats.IsPass = false;
        _powerUpUi.SwitchPasIcon(false);
    }
    IEnumerator MegaphoneDownRoutin(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GlobalParameters.IsMegaphonePicked = false;
        PlayerStats.IsMegaphone = false;
        _powerUpUi.SwitchMegaphoneIcon(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Citizen") && !PlayerStats.IsPass)
        {
            ChangeHeart(-1);
            PlayerStats.Audio.Play("Bump",false);
        }
        if(other.gameObject.CompareTag("Garbage"))
        {

        }
    }
}
