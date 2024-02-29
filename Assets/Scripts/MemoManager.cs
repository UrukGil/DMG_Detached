using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using TMPro;

public class MemoManager : MonoBehaviour
{
    public GameObject UiElement;
    [SerializeField] string letter;
    [SerializeField] GameObject letterUI = null;
    [SerializeField] float alpha = 0f;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    letterUI = GameObject.FindGameObjectWithTag(tempList[i]);
                    if (letterUI != null){
                        letterUI.GetComponent<TMP_Text>().font = Resources.Load("FKRASTERGROTESKTRIAL-SHARP SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
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

    public void CloseMemo()
    {
        GameObject memo = GameObject.FindGameObjectWithTag("Memo");
        memo.transform.GetChild(0).gameObject.SetActive(false);
        UiElement.SetActive(false);
        //UiElement.SetActive(!UiElement.activeSelf);
    }
}
