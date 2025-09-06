using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCitizens : MonoBehaviour
{
    [SerializeField] GameObject _citizen;
    [SerializeField] GameObject _globalParametersObject;
    [SerializeField] float _spawnAbsolutePosition;
    [SerializeField] float _initialSpawnRate;
    float _spawnRate;
    WalkingRaws _walkingRaws;
    GlobalParameters _globalParameters;
    Vector3 _position = new Vector3(0, 1.6f, 0);
    Vector3 _rotation = new Vector3(0, 0, 0);
    void Start()
    {
        _globalParameters = _globalParametersObject.GetComponent<GlobalParameters>();
        //_citizen.GetComponent<Citizen>().GlobalParameters = _globalParameters;
        _walkingRaws = GameObject.Find("MeasurmentPlane").GetComponent<WalkingRaws>();
        StartSpawn();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnCitizen()
    {
        if(_globalParameters.IsGameRun)
        {
            int rawIndex = Random.Range(0, _walkingRaws.RawsCount);
            if (rawIndex % 2 == 0)
            {
                AutoCreationCitizen(rawIndex, -1);
            }
            else
            {
                AutoCreationCitizen(rawIndex, 1);
            }
        }
    }
    void AutoCreationCitizen(int index,int flag)
    {

        _position.x = flag * _spawnAbsolutePosition; ;
        _position.z = -1 * _walkingRaws.RawsPositions[index];
        _rotation.y = flag * -90;
        _citizen.transform.eulerAngles = _rotation;
        Instantiate(_citizen, _position, _citizen.transform.rotation);
    }
    public void StartSpawn()
    {
        _spawnRate = _initialSpawnRate;
        InvokeRepeating("DoubleTrouble", 0, 30);
    }
    public void  DoubleTrouble()
    {
        //_globalParameters.DoubleTrouble();
        CancelInvoke("SpawnCitizen");
        InvokeRepeating("SpawnCitizen", 0, _spawnRate);
        _spawnRate /= 2;
        
    }
}
