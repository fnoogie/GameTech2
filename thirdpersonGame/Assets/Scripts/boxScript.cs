using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{

    public bool gravityOn = true, oppositeGravity = false;
    public Material followGrav, oppositeGrav;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gravityOn)
        {
            if (oppositeGravity)
                rb.AddForce(Physics.gravity * rb.mass * -1);
            else
                rb.AddForce(Physics.gravity * rb.mass);
        }

        if (oppositeGravity)
            gameObject.GetComponent<MeshRenderer>().material = oppositeGrav;
        else
            gameObject.GetComponent<MeshRenderer>().material = followGrav;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("OppositeGravPaint"))
            oppositeGravity = true;
        else if (other.name.Contains("FollowGravPaint"))
            oppositeGravity = false;   
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name.Contains("BoxActivatedButton"))
        {
            other.gameObject.GetComponent<buttonScript>().activated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("BoxActivatedButton"))
        {
            other.gameObject.GetComponent<buttonScript>().activated = false;
        }
    }
    
}
