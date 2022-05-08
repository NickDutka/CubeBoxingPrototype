using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _spaceObjects;

    [SerializeField]
    private float _spawnRangeX = 40;

    [SerializeField]
    private float _spawnRangeYmin = 0;

    [SerializeField]
    private float _spawnRangeYmax = 2;

    [SerializeField]
    private float _spawnPosZ = 500;
    
    [SerializeField]
    private float _startDelay = 2;

    [SerializeField]
    private float _spawnInterval = 1.5f;

    [SerializeField]
    private float _rotationRangeZ = 360f;

    void Start()
    {
        InvokeRepeating("SpawnRandomSpaceObject", _startDelay, _spawnInterval);
    }

    
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    SpawnRandomAnimal();
        //}
    }

    void SpawnRandomSpaceObject()
    {

        int _spaceObjectsIndex = Random.Range(0, _spaceObjects.Length);
        Vector3 _spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), Random.Range(_spawnRangeYmin, _spawnRangeYmax), _spawnPosZ);
        Quaternion _spawnRotation = new Quaternion(Random.Range(-_rotationRangeZ, _rotationRangeZ), 180, 0, 0);

        Instantiate(_spaceObjects[_spaceObjectsIndex], _spawnPos, _spawnRotation);
    }
}
