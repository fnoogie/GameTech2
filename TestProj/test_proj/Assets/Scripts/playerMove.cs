using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    Vector3 playerMovementVec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            this.gameObject.transform.position += playerMovement();
            //this.gameObject.transform.rotation = Quaternion.Euler(transform.GetChild(0).rotation.x % 360f, 0,0);
            gameObject.transform.forward = transform.GetChild(0).forward;
        
    }

    Vector3 playerMovement()
    {
        playerMovementVec = new Vector3(Input.GetAxis("Horizontal") * gameObject.transform.right.x + Input.GetAxis("Vertical") * gameObject.transform.forward.x, 0, Input.GetAxis("Horizontal") * gameObject.transform.right.z + Input.GetAxis("Vertical") * gameObject.transform.forward.z);
        return playerMovementVec * 3 * Time.deltaTime;
    }
}
