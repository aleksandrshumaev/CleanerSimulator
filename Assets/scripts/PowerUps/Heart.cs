using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerInteractions = collision.gameObject.GetComponent<PlayerInteractions>();
            _playerInteractions.ChangeHeart(1);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
}
