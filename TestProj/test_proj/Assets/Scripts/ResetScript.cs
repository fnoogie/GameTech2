using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    GameManagerScript GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("toCollect"))
        {
            Destroy(other.gameObject);
            GM.newSpawn();
        }
        else if(other.gameObject.name.Contains("Player"))
        {
            other.gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }
}
