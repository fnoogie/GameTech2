using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class uniqueButton : MonoBehaviour
{
    public string onMouseHoverText;
    public GameObject textPanel;
    public TextMeshProUGUI text;
    public bool rightSide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMouseOver()
    {
        if(rightSide)
        {
            
        }
        textPanel.transform.position = gameObject.transform.position;
        textPanel.SetActive(true);
        text.text = onMouseHoverText;
    }

    public void OnMouseExit()
    {
        textPanel.SetActive(false);
        text.text = "";
    }

    public  void OnMouseEnter()
    {
        textPanel.transform.position = gameObject.transform.position;
        textPanel.SetActive(true);
        text.text = onMouseHoverText;
    }

    
}
