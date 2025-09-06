using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingRaws : MonoBehaviour
{
    [SerializeField] GameObject _leftPoint;
    [SerializeField] GameObject _rightPoint;
    float _rawWidth = 2;
    int _rawsCount;
    float _rawsAreaWidth;
    List<float> _rawsPositions = new List<float>();
    List<bool> _rawsBusines = new List<bool>();

    public int RawsCount { get => _rawsCount; set => _rawsCount = value; }
    public List<float> RawsPositions { get => _rawsPositions; set => _rawsPositions = value; }

    // Start is called before the first frame update
    void Start()
    {
        _rawsAreaWidth=_leftPoint.transform.position.z - _rightPoint.transform.position.z;
        _rawsCount = Mathf.FloorToInt(_rawsAreaWidth / _rawWidth);
        _rawWidth = _rawsAreaWidth / _rawsCount;
        CreateRawsPositionsList();
    }
    void CreateRawsPositionsList()
    {
        _rawsPositions.Add(_leftPoint.transform.position.z+_rawWidth / 2);
        _rawsBusines.Add(false);
        for(int i=1;i<_rawsCount;i++)
        {
            _rawsPositions.Add(_rawsPositions[i - 1] + _rawWidth);
            _rawsBusines.Add(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
