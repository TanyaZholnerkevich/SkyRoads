using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
