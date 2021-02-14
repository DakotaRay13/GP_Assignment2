using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public  bool isPaused;

    public InputActions input;

    private void Awake()
    {
        input = new InputActions();
    }
    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;

        input.Player.Pause.performed += _ => CheckPause();
    }

    // Update is called once per frame
    void CheckPause()
    {
        if(isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;

        Application.Quit();
    }
}
