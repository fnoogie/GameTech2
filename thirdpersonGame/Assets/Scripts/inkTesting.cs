using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;

public class inkTesting : MonoBehaviour
{
    bool waiting = false, finished = false;
    public float timeBetweenLines = 5f;
    public TextMeshProUGUI textbox;
    public TextAsset inkJSONAsset;
    public Story story;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJSONAsset.text);
        story.Continue();
    }

    // Update is called once per frame
    void Update()
    {
        if (story.canContinue)
        {
            finished = false;
            if (!waiting)
                StartCoroutine(nextTextLine());
            textbox.text = story.currentText;
        }
        else
            finished = true;

        if(!waiting && finished)
        {
            //textbox.text = "";
            textbox.transform.parent.gameObject.SetActive(false);
        }
    }

    IEnumerator nextTextLine()
    {
        waiting = true;
        yield return new WaitForSeconds(timeBetweenLines);
        story.Continue();
        waiting = false;
    }

}
