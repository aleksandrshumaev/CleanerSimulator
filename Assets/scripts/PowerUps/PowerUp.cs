using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PowerUp : MonoBehaviour
{
    [SerializeField] protected float _baseTime;
    [SerializeField] protected float _timeUpPerLevel;
    protected PlayerInteractions _playerInteractions;
    protected PlayerStats _playerStats;
    protected PowerUpSpawn _powerUpSpawn;
    protected AudioSource _audioSource;
    protected void Start()
    {
        _powerUpSpawn = GameObject.Find("PowerUpSpawn").GetComponent<PowerUpSpawn>();
        _playerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
        _audioSource = GetComponent<AudioSource>();
        //SpawnManager assign
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {

    }
    protected void OnDestroy()
    {
        //SpawnManager message that place at transpose.Position is clear
        _playerStats.Audio.Play("PowerUpPickUp",false);
        _powerUpSpawn.PowerUpDestroyed(gameObject.transform.position);
    }
}
