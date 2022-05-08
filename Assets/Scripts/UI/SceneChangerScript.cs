using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    public void LevelSelect() 
    {
        SceneManager.LoadScene("Level Select");
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
