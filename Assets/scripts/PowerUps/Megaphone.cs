using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaphone : PowerUp
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //_playerStats = collision.gameObject.GetComponent<PlayerStats>();
            _playerInteractions = collision.gameObject.GetComponent<PlayerInteractions>();
            float time = _baseTime + _timeUpPerLevel * _playerStats.MegaphoneLevel;
            _playerInteractions.PickUpMegaphone(time);
            Destroy(gameObject);
        }
    }
}
