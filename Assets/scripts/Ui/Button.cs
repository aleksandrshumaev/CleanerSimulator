using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
   PlayerStats _playerStats;

    public PlayerStats PlayerStats { get => _playerStats; set => _playerStats = value; }

    protected virtual void Awake()
    {
        PlayerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
    }
    public void OnBottonClick()
    {
        PlayerStats.Audio.Play("MenuClick", false);
    }
}
