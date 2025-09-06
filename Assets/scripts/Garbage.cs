using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] float _sturdiness;
    [SerializeField] int _revenu;
    PlayerInteractions _playerInteractions;
    PlayerStats _playerStats;
    float _cleanPower;
    bool _isCleaningUp;
    Color _initialColor;
    Material _material;
    List<Renderer> _renderers = new List<Renderer>();
    GarbageSpawn _garbageSpawn;

    public bool IsCleaningUp { get => _isCleaningUp; set => _isCleaningUp = value; }

    private void Start()
    {
        _garbageSpawn = GameObject.Find("GarbageSpawn").GetComponent<GarbageSpawn>();
        //_material = GetComponent<Renderer>().material;
        _initialColor = Color.black;
       foreach(Transform child in transform)
        {
            _renderers.Add(child.gameObject.GetComponent<Renderer>());
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
            _playerInteractions = other.gameObject.GetComponent<PlayerInteractions>();
            _playerStats = _playerInteractions.PlayerStats;
            _playerStats.Audio.Play("Cleaning",true);
            ChangeColor(Color.green);
            //_cleanPower=Mathf.Pow(_playerStats.CleanPower,_playerStats.Cle);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerStats.Audio.Stop("Cleaning");
            _playerInteractions = null;
            _playerStats = null;
            ReturnColor();
        }

        //_material.color
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(_sturdiness>0)
            {
                _sturdiness -= _playerStats.CleanSpeed*Time.deltaTime;
            }
            else
            {
                _playerInteractions.GetRevenu(_revenu);
                _playerStats.Audio.Stop("Cleaning");
                Destroy(gameObject);
            }
        }
    }
    void ChangeColor(Color color)
    {
       foreach(Renderer renderer in _renderers)
        {
            renderer.material.SetColor("_Color", color);
        }
    }
    void ReturnColor()
    {
        foreach (Renderer renderer in _renderers)
        {
            renderer.material.SetColor("_Color", _initialColor);
        }
    }
    private void OnDestroy()
    {

        _garbageSpawn.GarbageBagDestroy(gameObject.transform.position);
    }
}
