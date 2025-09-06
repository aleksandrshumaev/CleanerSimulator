using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 _offset;
    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("player"); 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _player.transform.position + _offset;
    }
}
