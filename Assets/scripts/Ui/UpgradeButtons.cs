using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : Button
{
    int _baseCost=1000;
    float _costUpPerLevel=1.3f;
    //PlayerStats _playerStats;
    [SerializeField] Text _speedUpCost;
    [SerializeField] Text _cleanSpeedUpCost;
    [SerializeField] Text _revenuUpCost;
    [SerializeField] Text _passCost;
    [SerializeField] Text _megaphoneCost;
    [SerializeField] Text _revenuStatCost;
    [SerializeField] Text _cleanSpeedStatCost;
    [SerializeField] Text _timeCost;
    [SerializeField] Text _money;
    [SerializeField] Text _speedUpDiscription;
    [SerializeField] Text _cleanSpeedUpDiscription;
    [SerializeField] Text _revenuUpDiscription;
    [SerializeField] Text _passDiscription;
    [SerializeField] Text _megaphoneDiscription;
    [SerializeField] Text _revenuStatDiscription;
    [SerializeField] Text _cleanSpeedStatDiscription;
    [SerializeField] Text _timeDiscription;
    public int BaseCost { get => _baseCost; set => _baseCost = value; }
    public float CostUpPerLevel { get => _costUpPerLevel; set => _costUpPerLevel = value; }

    void Start()
    {
        // base.Start();
        _speedUpDiscription.text = PlayerStats.Localization.GetLocalizationFor("SpeedUpDiscription"); ;
        _cleanSpeedUpDiscription.text = PlayerStats.Localization.GetLocalizationFor("CleanSpeedUpDiscription"); ;
        _revenuUpDiscription.text = PlayerStats.Localization.GetLocalizationFor("RevenuUpDiscription"); ;
        _passDiscription.text = PlayerStats.Localization.GetLocalizationFor("PassDiscription"); ;
        _megaphoneDiscription.text = PlayerStats.Localization.GetLocalizationFor("MegaphoneDiscription"); ;
        _revenuStatDiscription.text = PlayerStats.Localization.GetLocalizationFor("RevenuStatDiscription"); ;
        _cleanSpeedStatDiscription.text = PlayerStats.Localization.GetLocalizationFor("CleanSpeedStatDiscription"); ;
        _timeDiscription.text= PlayerStats.Localization.GetLocalizationFor("TimeDiscription"); ;
        PlayerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
        _speedUpCost.text = Mathf.FloorToInt(Mathf.FloorToInt(BaseCost * Mathf.Pow(CostUpPerLevel, PlayerStats.SpeedUpLevel))).ToString();
        _cleanSpeedUpCost.text = Mathf.FloorToInt(Mathf.FloorToInt(BaseCost * Mathf.Pow(CostUpPerLevel, PlayerStats.CleanSpeedUpLevel))).ToString();
        _revenuUpCost.text = Mathf.FloorToInt(Mathf.FloorToInt(BaseCost * Mathf.Pow(CostUpPerLevel, PlayerStats.RevenuUpLevel))).ToString();
        _passCost.text = Mathf.FloorToInt(Mathf.FloorToInt(BaseCost * Mathf.Pow(CostUpPerLevel, PlayerStats.PassLevel))).ToString();
        _megaphoneCost.text = Mathf.FloorToInt(Mathf.FloorToInt(BaseCost * Mathf.Pow(CostUpPerLevel, PlayerStats.MegaphoneLevel))).ToString();
        _revenuStatCost.text = Mathf.FloorToInt(Mathf.FloorToInt(BaseCost * Mathf.Pow(CostUpPerLevel, PlayerStats.RevenuStatLevel))).ToString();
        _cleanSpeedStatCost.text = Mathf.FloorToInt(Mathf.FloorToInt(BaseCost * Mathf.Pow(CostUpPerLevel, PlayerStats.CleanSpeedStatLevel))).ToString();
        _timeCost.text = Mathf.FloorToInt(Mathf.FloorToInt(BaseCost * Mathf.Pow(CostUpPerLevel, PlayerStats.Timelevel))).ToString();
        RefreshMoneyCount();
    }
    // Start is called before the first frame update
    public void SpeedUpUpgrade()
    {
        OnBottonClick();
        int cost = Mathf.FloorToInt(BaseCost * (Mathf.Pow(CostUpPerLevel, PlayerStats.SpeedUpLevel)));
        if (HaveEnoughMoney(cost))
        {
            PlayerStats.SpeedUpLevel += 1;
            _speedUpCost.text = Mathf.FloorToInt(cost * CostUpPerLevel).ToString();
        }
    }
    public void CleanSpeedUpUpgrade()
    {
        OnBottonClick();
        int cost = Mathf.FloorToInt(BaseCost * (Mathf.Pow(CostUpPerLevel, PlayerStats.CleanSpeedUpLevel)));
        if (HaveEnoughMoney(cost))
        {
            PlayerStats.CleanSpeedUpLevel += 1;
            _cleanSpeedUpCost.text = Mathf.FloorToInt(cost * CostUpPerLevel).ToString();
        }
    }
    public void RevenudUpUpgrade()
    {
        OnBottonClick();
        int cost = Mathf.FloorToInt(BaseCost * (Mathf.Pow(CostUpPerLevel, PlayerStats.RevenuUpLevel)));
        if (HaveEnoughMoney(cost))
        {
            PlayerStats.RevenuUpLevel += 1;
            _revenuUpCost.text = Mathf.FloorToInt(cost * CostUpPerLevel).ToString();
        }
    }
    public void PassUpgrade()
    {
        OnBottonClick();
        int cost = Mathf.FloorToInt(BaseCost * (Mathf.Pow(CostUpPerLevel, PlayerStats.PassLevel)));
        if (HaveEnoughMoney(cost))
        {
            PlayerStats.PassLevel += 1;
            _passCost.text = Mathf.FloorToInt(cost * CostUpPerLevel).ToString();
        }
    }
    public void MegaphoneUpgrade()
    {
        OnBottonClick();
        int cost = Mathf.FloorToInt(BaseCost * (Mathf.Pow(CostUpPerLevel, PlayerStats.MegaphoneLevel)));
        if (HaveEnoughMoney(cost))
        {
            PlayerStats.MegaphoneLevel += 1;
            _megaphoneCost.text = Mathf.FloorToInt(cost * CostUpPerLevel).ToString();
        }
    }
    public void RevenuStatUpgrade()
    {
        OnBottonClick();
        int cost = Mathf.FloorToInt(BaseCost * (Mathf.Pow(CostUpPerLevel, PlayerStats.RevenuStatLevel)));
        if (HaveEnoughMoney(cost))
        {
            PlayerStats.RevenuStatLevel += 1;
            _revenuStatCost.text = Mathf.FloorToInt(cost * CostUpPerLevel).ToString();
        }
    }
    public void CleanSpeedStatUpgrade()
    {
        OnBottonClick();
        int cost = Mathf.FloorToInt(BaseCost * (Mathf.Pow(CostUpPerLevel, PlayerStats.CleanSpeedStatLevel)));
        if (HaveEnoughMoney(cost))
        {
            PlayerStats.CleanSpeedStatLevel += 1;
           _cleanSpeedStatCost.text = Mathf.FloorToInt(cost * CostUpPerLevel).ToString();
        }
    }
    public void TimeStatUpgrade()
    {
        OnBottonClick();
        int cost = Mathf.FloorToInt(BaseCost * (Mathf.Pow(CostUpPerLevel, PlayerStats.Timelevel)));
        if (HaveEnoughMoney(cost))
        {
            PlayerStats.Timelevel += 1;
            _timeCost.text = Mathf.FloorToInt(cost * CostUpPerLevel).ToString();
        }
    }
    bool HaveEnoughMoney(int cost)
    {

        if (PlayerStats.Money > cost)
        {
            PlayerStats.Money -= cost;
            RefreshMoneyCount();
            return true;
        }
        else
        {
            return false;
        }
    }
    void RefreshMoneyCount()
    {
        _money.text = (100000000000 + PlayerStats.Money).ToString().Substring(1) + "$";
    }
}
