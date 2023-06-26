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



    private void Start()
    {
        //audioManager = AudioManager.instance;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
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
        SceneManager.LoadScene(0);
    }

    public void BtSound()
    {
        //audioManager.Play("Button");
    }
    public void BackBtSound()
    {
        //audioManager.Play("BackBt");
    }
    public void BuyBtSound()
    {
        //audioManager.Play("BuyBt");
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    other.GetComponent<Wincheck>()?.Win;
    //}
    
    
}
