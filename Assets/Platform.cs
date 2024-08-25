using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public int startingPoint;
    public Transform[] points;
    private int i;
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, points[i].position)<0.01f){
            i++;
            if(i==points.Length){
                i=0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //  && transform.position.y<other.transform.position.y-0.5f
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.transform.SetParent(this.transform);
            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();
            playerRb.velocity = Vector2.zero;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.transform.SetParent(null);
        }
    }
}
