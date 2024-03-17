using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using TMPro;
using System.Linq;
public class MemoManager : MonoBehaviour
{
    public GameObject UiElement;
    [SerializeField] string letter;
    [SerializeField] GameObject[] letterUIArray;
    [SerializeField] float alpha = 0f;
    public int memoClosedTimes = 0;
    private GameObject player;
    
    public bool PlayerCanTab = true;
    List<string> tags = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        string string1 = "Vegetable";
        string string2 = "Magazine";
        string string3 = "Wine";
        string string4 = "Photo";
        string string5 = "Newspaper";
        string string6 = "Birthday";
        string string7 = "All";
        tags.Add(string1);
        tags.Add(string2);
        tags.Add(string3);
        tags.Add(string4);
        tags.Add(string5);
        tags.Add(string6);
        tags.Add(string7);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject memo = GameObject.FindGameObjectWithTag("Memo");
        player = GameObject.FindWithTag("Player");
        Vector2 playerPos = player.transform.position;
        memo.transform.GetChild(0).position = new Vector2(playerPos.x, playerPos.y);
        if (!UiElement.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                UiElement.SetActive(true);
                memo.transform.GetChild(0).gameObject.SetActive(true);
                List<string> tempList = GameManager.Instance.GetItems();
                for (int i = 0; i < tempList.Count; i++){
                    alpha = 0f;
                    if (tags.Contains(tempList[i]))
                    {
                        letterUIArray = GameObject.FindGameObjectsWithTag(tempList[i]);
                        foreach (GameObject letterUI in letterUIArray)
                        {
                            if (letterUI != null){
                                letterUI.GetComponent<TMP_Text>().font = Resources.Load("FKRASTERGROTESKTRIAL-SHARP SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
                            }
                        }
                    }
                }
            }
        }
        else if (UiElement.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab)&& PlayerCanTab == true)
            {
                UiElement.SetActive(!UiElement.activeSelf);
            }
        }

    }

    public void CloseMemo()
    {
        GameObject memo = GameObject.FindGameObjectWithTag("Memo");
        memo.transform.GetChild(0).gameObject.SetActive(false);
        UiElement.SetActive(false);
        //UiElement.SetActive(!UiElement.activeSelf);
    }
}
