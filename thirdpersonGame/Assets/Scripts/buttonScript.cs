using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public bool activated;
    public Material off, on;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
            gameObject.GetComponent<MeshRenderer>().material = on;
        else
            gameObject.GetComponent<MeshRenderer>().material = off;
    }
}
