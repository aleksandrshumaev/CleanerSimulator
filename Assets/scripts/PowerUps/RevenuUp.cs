using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevenuUp : PowerUp
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //_playerStats = collision.gameObject.GetComponent<PlayerStats>();
            _playerInteractions = collision.gameObject.GetComponent<PlayerInteractions>();
            float time = _baseTime + _timeUpPerLevel * _playerStats.RevenuUpLevel;
            _playerInteractions.PickUpRevenuUp(time);
            Destroy(gameObject);
        }
    }
}
