using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject _restartButton;

    public void GameOver()
    {
        Time.timeScale = 0;
        _restartButton.SetActive(true);
    }
}
