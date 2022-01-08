using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject _startText;

    private void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            _startText.SetActive(false);
        }
    }
}
