using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using TMPro;

public class MemoManager : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject UIElement;
=======
    public GameObject UiElement;
    [SerializeField] string letter;
    [SerializeField] GameObject letterUI = null;
    [SerializeField] float alpha = 0f;
<<<<<<< Updated upstream
=======
>>>>>>> 862a44b418a06aa9b7bc058a1a0d2695e1f6c7c8
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!UIElement.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
<<<<<<< HEAD
                UIElement.SetActive(true);
=======
                UiElement.SetActive(true);
                GameObject memo = GameObject.FindGameObjectWithTag("Memo");
                memo.transform.GetChild(0).gameObject.SetActive(true);
                List<string> tempList = GameManager.Instance.GetItems();
                for (int i = 0; i < tempList.Count; i++){
                    alpha = 0f;
                    letterUI = GameObject.FindGameObjectWithTag(tempList[i]);
                    if (letterUI != null){
                        letterUI.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 255);
                    }
                }
<<<<<<< Updated upstream
=======
>>>>>>> 862a44b418a06aa9b7bc058a1a0d2695e1f6c7c8
>>>>>>> Stashed changes
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
