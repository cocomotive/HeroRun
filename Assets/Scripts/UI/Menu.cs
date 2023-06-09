using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{

    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public AudioManager audioManager;
    public CurrencyManager currencyManager;
    public GameObject loseMenuUI;

    public static SaveJson json;

    private void Start()
    {
        audioManager = AudioManager.instance;
        json = SaveJson.instance;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        json.LoadGame();
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void ResueGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    public void ResetLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void LoadLvl2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }
    public void LoadMinigame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void BtSound()
    {
        audioManager.PlaySfx(audioManager.button);
    }
    public void BackBtSound()
    {
        audioManager.PlaySfx(audioManager.backBt);
    }
    public void BuyBtSound()
    {
        audioManager.PlaySfx(audioManager.coin);
    }
    public void LoseUI()
    {
        loseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    other.GetComponent<Wincheck>()?.Win;
    //}


}
