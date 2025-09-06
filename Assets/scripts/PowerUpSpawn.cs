using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    [SerializeField] float _spawnRate;
    [SerializeField] GameObject[] _positions = new GameObject[4];
    [SerializeField] PowerUp[] _powerUps = new PowerUp[6];
    [SerializeField] GlobalParameters _globalParameters;
    Dictionary<string, bool> _isPositionBusy = new Dictionary<string, bool>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject position in _positions)
        {
            _isPositionBusy.Add(position.transform.position.x.ToString() + " - " + position.transform.position.z.ToString(), false);
        }
        InvokeRepeating("SpawnPowerUp", 1, _spawnRate);
    }
    void SpawnPowerUp()
    {
        if(_globalParameters.IsGameRun)
        {
            Vector3 position = _positions[Random.Range(0, 4)].transform.position;
            if (!_isPositionBusy[position.x.ToString() + " - " + position.z.ToString()])
            {
                PowerUp powerUp = _powerUps[Random.Range(0, _powerUps.Length)];
                Instantiate(powerUp, position, powerUp.transform.rotation);
                _isPositionBusy[position.x.ToString() + " - " + position.z.ToString()] = true;
            }
        }

    }
    public void PowerUpDestroyed(Vector3 position)
    {
        _isPositionBusy[position.x.ToString() + " - " + position.z.ToString()] = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
