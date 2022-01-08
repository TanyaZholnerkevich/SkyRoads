using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _recordText;
    [SerializeField] private Text _newRecordText;

    private int _score = 0;
    private int _gameScore = 0;
    private float _timer = 0;
    private int _record = 0;

    private AsteroidSpawner _asteroidSpawner;
    private void Awake()
    {
        _asteroidSpawner = GetComponent<AsteroidSpawner>();

        if (PlayerPrefs.HasKey("Record"))
        {
            _gameScore = PlayerPrefs.GetInt("Record");
            _recordText.text = _record.ToString();
        }
    }

    private void Update()
    {
        CalculateScore();
        _scoreText.text = _gameScore.ToString();

        CalculateRecord();
    }

    private void CalculateScore()
    {
        _timer += 1 * Time.deltaTime;
        if (_timer > 1 && Input.GetKey(KeyCode.Space))
        {
            _score += 2;
            _timer = 0;
        }
        else if (_timer > 1 && !Input.GetKey(KeyCode.Space))
        {
            _score += 1;
            _timer = 0;
        }
        _gameScore = (_asteroidSpawner._asteroidCount) * 5 + _score;
    }

    private void CalculateRecord()
    {
        if (_gameScore > _record)
        {
            _record = _gameScore;
            PlayerPrefs.SetInt("Record", _record);
            PlayerPrefs.Save();
            _recordText.text = _record.ToString();
            _newRecordText.text = "New Record!!!";
        }
        else
        {
            _recordText.text = _record.ToString();
        }

        _record = PlayerPrefs.GetInt("Record");
    }
}
