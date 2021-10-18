using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{
    Vector3 initialPos;
    public bool gravityOn = true, oppositeGravity = false;
    public Material followGrav, oppositeGrav;
    Rigidbody rb;
    playerScript player;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerScript>();
        initialPos = gameObject.transform.position;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Pickup"))
        {
            if (player.findClosestObj() == this.gameObject)
            {
                if (player.carryObj = this.gameObject)
                    player.carryObj = null;
                player.pickupObjects.Remove(this.gameObject);
            }
            gameObject.transform.position = initialPos;
            gravityOn = true;
            oppositeGravity = false;
            rb.velocity = Vector3.zero;

        }
    }
}
