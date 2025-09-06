using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [SerializeField] Sound[] _sounds;
    Dictionary<string, Sound> _audioClip = new Dictionary<string, Sound>();
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound soundTrack in _sounds)
        {
            soundTrack.AudioSource = gameObject.AddComponent<AudioSource>();
            soundTrack.AudioSource.clip = soundTrack.Clip;
            soundTrack.AudioSource.volume = soundTrack.Volume;
            _audioClip.Add(soundTrack.Name, soundTrack);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(string name, bool isLoop)
    {
        if(_audioClip.ContainsKey(name)&& _audioClip[name].AudioSource!= null)
        {
            _audioClip[name].AudioSource.loop = isLoop;
            _audioClip[name].AudioSource.Play();
        }
    }
    public void Stop(string name)
    {
        if (_audioClip.ContainsKey(name) && _audioClip[name].AudioSource != null)
        {
            _audioClip[name].AudioSource.Stop();
        }
    }
}
