using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    private void OnRetry(InputValue value)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void OnMenu(InputValue value)
    {
        SceneManager.LoadScene("Main Menu");
    }
}
