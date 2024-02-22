using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using TMPro;

public class MemoManager : MonoBehaviour
{
    public GameObject UiElement;
    [SerializeField] string letter = "";
    [SerializeField] GameObject letterUI = null;
    [SerializeField] float alpha = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!UiElement.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
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
