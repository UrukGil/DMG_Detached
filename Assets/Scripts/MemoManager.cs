using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class MemoManager : MonoBehaviour
{
    public GameObject UIElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!UIElement.activeSelf)
        {
            //print("s");
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                UIElement.SetActive(true);
            }
        }
        else if (UIElement.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                UIElement.SetActive(!UIElement.activeSelf);
            }
        }

    }
}
