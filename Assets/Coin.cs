using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float bounceHeight = 0.5f;
    public float bounceSpeed = 2f;
    private Vector3 originalPosition;
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight + originalPosition.y;
        transform.position = new Vector3(originalPosition.x ,newY, originalPosition.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;
            Debug.Log("Coin collected!");
            GameManager.Instance.Plus();
            Destroy(gameObject);
        }
    }
}
