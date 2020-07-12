using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_platform : MonoBehaviour
{

    public GameObject waypointA;                
    public GameObject waypointB;                
    public float speed = 1;                     
    private bool directionAB = true;            

    void FixedUpdate()
    {
        if (this.transform.position == waypointA.transform.position && directionAB == false
           || this.transform.position == waypointB.transform.position && directionAB == true)
        {
            directionAB = !directionAB;
        }
        if (directionAB == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, waypointB.transform.position, speed * Time.fixedDeltaTime);
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, waypointA.transform.position, speed * Time.fixedDeltaTime);
        }
    }
}
