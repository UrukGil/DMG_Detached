using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class MemoManager : MonoBehaviour
{
    public GameObject UiElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!UiElement.activeSelf)
        {
            //print("s");
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                UiElement.SetActive(true);
            }
        }
        else if (UiElement.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                UiElement.SetActive(!UiElement.activeSelf);
            }
        }

    }
}
