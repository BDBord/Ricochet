using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPlayButton()
    {
        SceneManager.LoadScene(2);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(5);
    }

    public void Level1()
    {
        SceneManager.LoadScene(11);
    }

    public void Level2()
    {
        SceneManager.LoadScene(10);
    }

    public void Level3()
    {
        SceneManager.LoadScene(9);
    }

    public void Level4()
    {
        SceneManager.LoadScene(8);
    }

    public void Level5()
    {
        SceneManager.LoadScene(7);
    }

    public void Level6()
    {
        SceneManager.LoadScene(6);
    }
}
