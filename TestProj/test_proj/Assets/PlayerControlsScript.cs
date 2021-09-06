using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsScript : MonoBehaviour
{
    public bool playGame = true, shopping = false;
    Vector3 playerMovementVec;
    float speed = 2f;
    GameObject GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager");
        playerMovementVec = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (playGame)
        {
            this.gameObject.transform.position += playerMovement();
            //this.gameObject.transform.rotation = Quaternion.Euler(transform.GetChild(0).rotation.x % 360f, 0,0);
            gameObject.transform.forward = transform.GetChild(0).forward;
        }
        else if(!playGame && shopping)
        {
            //shop menu to buy upgrades
            //time increase +5 or +10s
            //1 pickup gives 2 sticks
            //stones are a thing now
        }
    }

    Vector3 playerMovement()
    {
        playerMovementVec = new Vector3(Input.GetAxis("Horizontal") * gameObject.transform.right.x + Input.GetAxis("Vertical") * gameObject.transform.forward.x, 0, Input.GetAxis("Horizontal") * gameObject.transform.right.z + Input.GetAxis("Vertical") * gameObject.transform.forward.z);
        return playerMovementVec * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("toCollect"))
        {
            if (other.gameObject.name.Contains("Stick"))
            {
                Destroy(other.gameObject);
                GM.GetComponent<GameManagerScript>().collectedStick();
                GM.GetComponent<GameManagerScript>().newSpawn();
            }
            else if (other.gameObject.name.Contains("Stone"))
            {
                Destroy(other.gameObject);
                GM.GetComponent<GameManagerScript>().collectedStone();
                GM.GetComponent<GameManagerScript>().newSpawn();
            }
        }
    }
}
