using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    void Start(){
        // GetComponent<Collider2D>().enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // GetComponent<Collider2D>().enabled = false;
            GameManager.Instance.GameOver();
        }
    }
}
