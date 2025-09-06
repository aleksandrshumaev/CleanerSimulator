using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [SerializeField] string _name;
    [SerializeField] AudioClip _clip;
    [Range(0f, 1f), SerializeField] float _volume;
    public AudioSource AudioSource { get; set;}
    public string Name { get => _name; set => _name = value; }
    public AudioClip Clip { get => _clip; set => _clip = value; }
    public float Volume { get => _volume; set => _volume = value; }
}
