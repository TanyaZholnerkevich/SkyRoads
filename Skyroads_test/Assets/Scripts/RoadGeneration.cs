using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _roadPrefab;
    [SerializeField] private Transform _playerShipPosition;

    private float _spawnPosition = 0.0f;
    private float _roadLength = 50.0f;
    private int _startRoadCounts = 5;

    private List<GameObject> _road = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < _startRoadCounts; i++)
        {
            SpawnRoad();
        }
    }

    private void Update()
    {
        if (_playerShipPosition.position.z - 60 > _spawnPosition - (_startRoadCounts * _roadLength))
        {
            SpawnRoad();
            DeleteRoad();
        }
    }

    private void SpawnRoad()
    {
        GameObject _nextRoadPrefab  = Instantiate(_roadPrefab, transform.forward * _spawnPosition, transform.rotation);
        _road.Add(_nextRoadPrefab);
        _spawnPosition += _roadLength;
    }

    private void DeleteRoad()
    {
        Destroy(_road[0]);
        _road.RemoveAt(0);
    }
}
