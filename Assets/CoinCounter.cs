using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter Instance;
    public int numCoin;
    public Text coinDisplay;
    private void Awake()
    {
        // If there is already an instance, and it's not this one, destroy this object
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: to persist across scenes
        }
    }
    void Start()
    {
        numCoin=0;
    }

    public void Plus(){
        Debug.Log(numCoin);
        numCoin++;
        coinDisplay.text = numCoin.ToString();
    }
}
