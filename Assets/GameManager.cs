using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    private bool isAlive;
    public int numCoin;
    public Text coinDisplay;
    private bool isPaused = false;
    public GameObject gameOverPanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        Setup();
    }
    void Setup(){
        numCoin=0;
        coinDisplay.text = "0";
        isAlive=true;
    }
    public bool GetAlive(){
        return isAlive;
    }

    public void Plus(){
        Debug.Log(numCoin);
        numCoin++;
        coinDisplay.text = numCoin.ToString();
    }
    public void GameOver(){
        gameOverPanel.SetActive(true);
        isAlive=false;
        player.GetComponent<NewPlayerMovement>().Death();
        // Time.timeScale = 0;
    }
    public void Replay(){
        Setup();
        SceneManager.LoadScene("Level_1");
    }
}
