using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] _garbageBags = new GameObject[3];
    [SerializeField] float _spawnRate;
    [SerializeField] int _xRightRange;
    [SerializeField] int _xLeftRange;
    [SerializeField] int _zTopRange;
    [SerializeField] int _zBotRange;
    [SerializeField] GlobalParameters _globalParameters;
    List<Vector3> _garbagePositions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        //_globalParameters=
        InvokeRepeating("SpwanGarbage", 1, _spawnRate);
    }
    void SpwanGarbage()
    {
        if(_globalParameters.IsGameRun)
        {
            Vector3 position = new Vector3(Random.Range(_xLeftRange, _xRightRange + 1), 0, Random.Range(_zBotRange, _zTopRange));
            if (!_garbagePositions.Contains(position))
            {
                GameObject garbage = _garbageBags[Random.Range(0, _garbageBags.Length)];
                Instantiate(garbage, position, garbage.transform.rotation);
            }
        }
    }
    public void GarbageBagDestroy(Vector3 position)
    {
        _garbagePositions.Remove(position);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
