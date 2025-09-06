using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float _defaultSpeed;
    [SerializeField] float _defaultCleanSpeed;
    // [SerializeField] float _speedUpPerLevel;
    [SerializeField] float _cleanSpeedUpPerLevel;
    [SerializeField] float _turnSpeed;
    [SerializeField] float _speed;
    [SerializeField] float _cleanSpeed;
    [SerializeField] int _initialHearts;
    [SerializeField] int _timeUpPerLevel;
    //[SerializeField] GameObject _globalParametersObject;
    //GlobalParameters _globalParameters;
    [SerializeField] int _money;
    DateTime _time;
    int _revenuStatLevel;
    int _cleanSpeedStatLevel;
    int _timelevel;
    int _speedUpLevel;
    int _cleanSpeedUpLevel;
    int _revenuUpLevel;
    int _passLevel;
    int _megaphoneLevel;
    bool _isSpeedUp;
    bool _isCleanSpeedUp;
    bool _isRevenuUp;
    bool _isPass;
    bool _isMegaphone;
    int _hearts;

    int _revenuForMission;

    public bool IsSpeedUp { get => _isSpeedUp; set => _isSpeedUp = value; }
    public bool IsCleanSpeedUp { get => _isCleanSpeedUp; set => _isCleanSpeedUp = value; }
    public bool IsRevenuUp { get => _isRevenuUp; set => _isRevenuUp = value; }
    public bool IsPass { get => _isPass; set => _isPass = value; }
    public bool IsMegaphone { get => _isMegaphone; set => _isMegaphone = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public float CleanSpeed { get => _cleanSpeed; set => _cleanSpeed = value; }
    public int SpeedUpLevel { get => _speedUpLevel; set => _speedUpLevel = value; }
    public int CleanSpeedUpLevel { get => _cleanSpeedUpLevel; set => _cleanSpeedUpLevel = value; }
    public int RevenuUpLevel { get => _revenuUpLevel; set => _revenuUpLevel = value; }
    public int PassLevel { get => _passLevel; set => _passLevel = value; }
    public int MegaphoneLevel { get => _megaphoneLevel; set => _megaphoneLevel = value; }
    public float DefaultCleanSpeed { get => _defaultCleanSpeed; set => _defaultCleanSpeed = value; }
    public float DefaultSpeed { get => _defaultSpeed; set => _defaultSpeed = value; }
    public float CleanSpeedUpPerLevel { get => _cleanSpeedUpPerLevel; set => _cleanSpeedUpPerLevel = value; }
    public float TurnSpeed { get => _turnSpeed; set => _turnSpeed = value; }
    public int Hearts
    {
        get
        {
            return _hearts;
        }
        set
        {
            if (value > 0)
                _hearts = value;
            else
            {
                _hearts = 0;
            }

        }
    }
    public int RevenuForMission { get => _revenuForMission; set => _revenuForMission = value; }
    public int Money { get => _money; set => _money = value; }
    public int RevenuStatLevel { get => _revenuStatLevel; set => _revenuStatLevel = value; }
    public int CleanSpeedStatLevel { get => _cleanSpeedStatLevel; set => _cleanSpeedStatLevel = value; }
    public int Timelevel { get => _timelevel; set => _timelevel = value; }
    public int TimeUpPerLevel { get => _timeUpPerLevel; set => _timeUpPerLevel = value; }
    public int InitialHearts { get => _initialHearts; set => _initialHearts = value; }
    public DateTime Time { get => _time; set => _time = value; }
    public Audio Audio { get; set; }
    public bool IsMoving { get; set; }
    public Localizations Localization {get;set;}
    public Advertisments Advertisment { get; set; }
    public bool HasReadMapTutor { get; set; } = false;
    public bool HasReadHomeTutor { get; set; } = false;
    public bool HasReadMissionTutor { get; set; } = false;
    public void SetSpeedToDefault()
    {
        Speed = DefaultSpeed;
    }
    public void SetCleanSpeedToDefault()
    {
        CleanSpeed = DefaultCleanSpeed;
    }
    void Start()
    {
        //Debug.Log("Check");
        Load();

    }
    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("PlayerStats");
        if(obj.Length>1)
        {
            Destroy(this.gameObject);
        }
        Localization = GetComponent<Localizations>();
        Audio = GetComponent<Audio>();
        Advertisment = GetComponent<Advertisments>();
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnApplicationQuit()
    {
        SaveStats.Save(this);
    }
    void Load()
    {
        PlayerData data = SaveStats.Load();
        if(data!=null)
        {
            Time = new DateTime(data.Year, data.Month, data.Day, data.Hour, data.Minute, data.Second);
            SpeedUpLevel = data.SpeedUpLevel;
            CleanSpeedUpLevel = data.CleanSpeedUpLevel;
            RevenuUpLevel = data.RevenuUpLevel;
            PassLevel = data.PassLevel;
            MegaphoneLevel = data.MegaphoneLevel;
            CleanSpeedStatLevel = data.CleanSpeedStatLevel;
            RevenuStatLevel = data.RevenuStatLevel;
            Timelevel = data.Timelevel;
        }
    }
    public void Move()
    {
        IsMoving = true;
        Audio.Play("FootStep", true);
    }
    public void StopMove()
    {
        IsMoving = false;
        Audio.Stop("FootStep");
    }

}
