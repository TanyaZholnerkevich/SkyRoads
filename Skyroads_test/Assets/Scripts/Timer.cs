using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    private float _startTime;
    private int _minutes = 0;
    private int _seconds = 0;

    private void Start()
    {
        _startTime = Time.time;
    }

    private void Update()
    {
        float _currentTime = Time.time - _startTime;
        _minutes = ((int)_currentTime / 60);
        _seconds = ((int)_currentTime % 60);

        _timerText.text = _minutes.ToString() + ":" + _seconds.ToString();
    }
}
