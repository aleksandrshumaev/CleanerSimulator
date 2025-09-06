using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanSpeedUp : PowerUp
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //_playerStats = collision.gameObject.GetComponent<PlayerStats>();
            _playerInteractions = collision.gameObject.GetComponent<PlayerInteractions>();
            float time = _baseTime + _timeUpPerLevel * _playerStats.CleanSpeedUpLevel;
            _playerInteractions.PickUpCleanSpeedUp(time);
            Destroy(gameObject);
        }
    }
}
