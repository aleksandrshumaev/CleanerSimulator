using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : PowerUp
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //_playerStats = collision.gameObject.GetComponent<PlayerStats>();
            _playerInteractions = collision.gameObject.GetComponent<PlayerInteractions>();
            float time = _baseTime + _timeUpPerLevel * _playerStats.PassLevel;
            _playerInteractions.PickUpPass(time);
            Destroy(gameObject);
        }
    }
}
