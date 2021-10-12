using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpCameraScript : MonoBehaviour
{
    float mouseX = 0f, mouseY = 0f, xRot = 0;
    public float mouseSpeed = 90f;
    public Transform player;

    bool mouseLock;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            toggleMouseLock();
        if (!player.gameObject.GetComponent<playerScript>().rotating)
        {
            mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSpeed;
            mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSpeed;

            player.Rotate(0f, Vector3.up.y * mouseX, 0f);
            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -80f, 40f);
            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        }
    }
    void toggleMouseLock()
    {
        mouseLock = !mouseLock;
        Cursor.lockState = mouseLock ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
