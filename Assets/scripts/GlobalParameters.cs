using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParameters : MonoBehaviour
{
    bool isGameRun;
    bool isMegaphonePicked;
    [SerializeField] float _citizenSpeed;
    [SerializeField] PlayerInteractions _playerInteractions;
    [SerializeField] float _initialTime;
    float _restTime;
    SpawnCitizens _spawnCitizens;
    public bool IsMegaphonePicked { get => isMegaphonePicked; set => isMegaphonePicked = value; }
    public bool IsGameRun { get => isGameRun; set => isGameRun = value; }
    public PlayerInteractions PlayerInteractions { get => _playerInteractions; set => _playerInteractions = value; }
    public float CitizenSpeed { get => _citizenSpeed; set => _citizenSpeed = value; }
    public float RestTime 
    {
        get
        {
            return _restTime;
        }
        set
        {
            if(value<0)
            {
                _restTime = 0;
                PlayerInteractions.GameOver();
            }
            else if(value>100)
            {
                _restTime = 100;
            }
            else
            {
                _restTime = value;
            }
        }
     }

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerInteractions.PlayerStats.HasReadMissionTutor)
        {
            IsGameRun = true;
        }
        _spawnCitizens = GameObject.Find("SpawnCitizens").GetComponent<SpawnCitizens>();
        _initialTime += PlayerInteractions.PlayerStats.Timelevel * PlayerInteractions.PlayerStats.TimeUpPerLevel;
        RestTime = _initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGameRun)
            RestTime -= 1 * Time.deltaTime;
    }
    public void ContinueGame()
    {
        RestTime = _initialTime;
        IsGameRun = true;
        PlayerInteractions.PlayerStats.Hearts = 2; 
        PlayerInteractions.PickUpPass(5);
        _spawnCitizens.StartSpawn();
        PlayerInteractions.PlayerStats.SetSpeedToDefault();
    }
    public void Awake()
    {
        PlayerInteractions.GlobalParameters = this;
    }
}
