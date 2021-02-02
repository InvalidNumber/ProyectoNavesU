using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;

    public static GameManager manager;
    public int enemyNumber;

    //teniamos puesto Start pero da error
    private void Awake()
    {
        manager = this;
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            UpdateScore(0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void UpdateScore(int num)
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            score += num;
            scoreText.text = score.ToString();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        int currentlevelNumber = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentlevelNumber + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
