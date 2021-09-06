using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Ground"))
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
        }
    }
}
