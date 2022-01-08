using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidsCount : MonoBehaviour
{
    [SerializeField] private Text _asteroidsText;

    private AsteroidSpawner _asteroidSpawner;

    void Awake()
    {
        _asteroidSpawner = GetComponent<AsteroidSpawner>();
    }

    void Update()
    {
        _asteroidsText.text = _asteroidSpawner._asteroidCount.ToString();
    }
}
