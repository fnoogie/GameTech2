using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    public GameObject camera;
    public float speed = 5, jumpPower = 5;
    Vector3 playerMovementVec;
    public bool rotating = false;
    bool canJump, canRotate;
    Vector3 gravDir;
    int rot;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (!rotating)
        {
            this.gameObject.transform.position += movement();
            if(canRotate)
                rotate();
            gravDir = new Vector3(Mathf.RoundToInt(transform.up.x), Mathf.RoundToInt(transform.up.y), Mathf.RoundToInt(transform.up.z)) * 3;
            
        }
        Physics.gravity = -gravDir;
        gameObject.GetComponent<Rigidbody>().useGravity = !rotating;

        //Vector3 dir = camera.transform.position - gameObject.transform.position;
        //transform.Rotate(0, dir.y, 0);
    }
    private void LateUpdate()
    {
        //transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
        /*
        if(!rotating)
            clampXZ();*/
    }

    Vector3 movement()
    {
        //var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;
        playerMovementVec = Input.GetAxis("Horizontal") * gameObject.transform.right + Input.GetAxis("Vertical") * gameObject.transform.forward;


        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            GetComponent<Rigidbody>().velocity += (gameObject.transform.up * jumpPower);
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
            clampRotations();

        return playerMovementVec * speed * Time.deltaTime;
    }

    void rotate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(rotateManager(new Vector3(0, 0, 90), 1f));
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(rotateManager(new Vector3(0, 0, -90), 1f));
        }
    }

    IEnumerator rotateManager(Vector3 direction, float rotDuration)
    {
        Quaternion fromRot = transform.localRotation;
        Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + direction);
        rotating = true;
        canRotate = false;
        GetComponent<Rigidbody>().velocity *= 0.3f;
        for (float i = 0f; i < 1; i += Time.deltaTime / rotDuration)
        {
            transform.rotation = Quaternion.Lerp(fromRot, toAngle, i);
            yield return null;
        }
        rotating = false;
        Mathf.Round(transform.rotation.x);
        Mathf.Round(transform.rotation.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
        canRotate = true;
    }

    void clampRotations()
    {
        if (transform.localRotation.y >= 45 && transform.localRotation.y < 135)
            rot = 90;
        else if (transform.localRotation.y >= 135 && transform.localRotation.y < 225)
            rot = 180;
        else if (transform.localRotation.y >= 225 && transform.localRotation.y < 315)
            rot = 270;
        else
            rot = 0;

        transform.localRotation = Quaternion.Euler(0, rot, transform.rotation.z);
    }
}
