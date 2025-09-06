using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    [SerializeField]float _speed;
    [SerializeField] GameObject _globalParametersObject;
    GlobalParameters _globalParameters;
    Animator _animator;

   

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _globalParameters = GameObject.Find("GlobalParametrs").GetComponent<GlobalParameters>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_globalParameters.IsGameRun && !_globalParameters.IsMegaphonePicked)
        {
            _animator.SetFloat("Speed_f", _speed);
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        if(transform.position.x>60 || transform.position.x < -60)
        {
            Destroy(gameObject);
        }
    }
}
