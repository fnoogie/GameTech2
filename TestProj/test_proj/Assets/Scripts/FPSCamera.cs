using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    Vector2 screenSize;
    // Start is called before the first frame update
    void Start()
    {
        screenSize.x = Screen.width;
        screenSize.y = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(Mathf.Clamp(Input.mousePosition.y - screenSize.y / 2,-60f,50f) * -1, Input.mousePosition.x - screenSize.x / 2,0);
        //gameObject.transform.rotation = Quaternion.AngleAxis((Input.mousePosition.y / 2), gameObject.transform.parent.forward) * Quaternion.AngleAxis((Input.mousePosition.x / 2), Vector3.up);
        
    }
}
