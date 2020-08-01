using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public GameObject PauseMenu, PauseButton, gameover, wonPannel, Stone;
    bool paused = false, isWon = false, gameOver = false;
    GameObject[] g = new GameObject[10];
    int rockIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
        gameover.SetActive(false);
        RandomInstanciate();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            } else
            {
                Pause();
            }            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }        

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        paused = true;
        PauseButton.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        paused = false;
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }    
    public void Gameover()
    {
        gameOver = true;
        gameover.SetActive(true);
    }
    public void Won()
    {
        isWon = true;
        wonPannel.SetActive(true);
    }

    public void RandomInstanciate()
    {
        if(g[rockIndex%10] != null)
        {
            Destroy(g[rockIndex % 10]);
        }
        g[rockIndex % 10] = Instantiate(Stone);
        rockIndex++;
        if (!isWon && !gameOver)
        {
            Invoke("RandomInstanciate", 1f);
        }        
    }    
}
