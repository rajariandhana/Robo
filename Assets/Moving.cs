using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=1f;
    public int startingPoint=0;
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
}
