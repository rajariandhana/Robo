using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    bool goingRight = true;
    int direction = 1;
    float runSpeed = 2f;
	private Rigidbody2D m_Rigidbody2D;
	private Vector3 m_Velocity = Vector3.zero;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
    void Awake()
    {
		m_Rigidbody2D = platform.GetComponent<Rigidbody2D>();
    }
    Vector2 current(){
        if(goingRight) return startPoint.position;
        else return endPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 target = current();
        // platform.position = Vector2.Lerp(platform.position, target, speed*Time.deltaTime);
        float move = direction * runSpeed * Time.fixedDeltaTime;
		Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        // float distance = (target-(Vector2)platform.position).magnitude;
        // if(distance<=0.1f){
        //     goingRight = !goingRight;
        //     direction *= -1;
        // }
        if(platform.position===startPoint.position || platform.position==endPoint.position){
            direction *= -1;
        }
        
    }
    private void  OnDrawGizmos() {
        if(platform && startPoint && endPoint){
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }
}
