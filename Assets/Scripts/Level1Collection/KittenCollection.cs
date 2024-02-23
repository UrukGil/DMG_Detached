using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KittenCollection : MonoBehaviour
{
    [SerializeField] string letter;
    private bool isTriggered = false;
    [SerializeField] GameObject letterUI = null;
    [SerializeField] float alpha = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetTrigger(bool value)
    {
        isTriggered = value;
    }

    public bool GetTrigger()
    {
        return isTriggered;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isTriggered == true )
        {
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
            letterUI = GameObject.FindGameObjectWithTag(letter);
            GameManager.Instance.AddItem(letter);
            alpha = 0f;
        }
        if (letterUI != null)
        {
            letterUI.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, Mathf.Min(255, alpha += Time.deltaTime / 2));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {  
        if (other.gameObject.tag == "Player")
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
    }
}
