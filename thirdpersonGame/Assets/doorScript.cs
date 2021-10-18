using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour
{
    public List<GameObject> buttonList;
    public string sceneToLoad;
    public Material doorOff, doorOn;
    public bool on = true;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject g in GameObject.FindObjectsOfType<GameObject>())
        {
            if(g.gameObject.TryGetComponent<buttonScript>(out buttonScript comp))
            {
                buttonList.Add(g);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < buttonList.Count; ++i)
        {
            if(!buttonList[i].GetComponent<buttonScript>().activated)
            {
                on = false;
                break;
            }
            on = true;
        }

        if (on)
            gameObject.GetComponent<MeshRenderer>().material = doorOn;
        else
            gameObject.GetComponent<MeshRenderer>().material = doorOff;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Player") && on)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
