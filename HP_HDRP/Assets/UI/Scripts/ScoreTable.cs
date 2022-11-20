using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTable : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
