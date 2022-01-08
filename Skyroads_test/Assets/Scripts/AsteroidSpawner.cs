using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _asteroidPrefab;
    [SerializeField] private Transform _playerShipPosition;

    private float _distance = 100.0f;
    private float _spawnPosition = 0.0f;
    private float _spawnTime = 1.1f;
    public int _asteroidCount = 0;
    private float _repeatTime = 60.0f;
    private float _currentTime;

    private List<GameObject> _asteroids = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(Spawn());

        _currentTime = _repeatTime;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        if(_currentTime <= 0 && _distance >= 40f && _spawnTime >= 0.5f)
        {
            _distance -= 10f;
            _spawnTime -= 0.1f;
            _currentTime = _repeatTime;
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_spawnTime);
        Vector3 _pos =  new Vector3(Random.Range(-3.7f, 3.7f), 1.0f, 130.0f + _spawnPosition);
        GameObject _nextAsteroid = Instantiate(_asteroidPrefab, _pos, Quaternion.identity);
        _asteroids.Add(_nextAsteroid);

        _spawnPosition += _distance;
        
        if( _asteroids[0].transform.position.z + 1 < _playerShipPosition.position.z)
        {
            _asteroidCount++;
            DeleteAsteroid();
        }
        RepeatCoroutine();
    }

    private void RepeatCoroutine()
    {
        StartCoroutine(Spawn());
    }

    private void DeleteAsteroid()
    {
        Destroy(_asteroids[0]);
        _asteroids.RemoveAt(0);
    }
}
