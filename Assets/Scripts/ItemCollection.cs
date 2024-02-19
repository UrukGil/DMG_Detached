using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    [SerializeField] string letter = "";
    private bool isPlayerInTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(letter);
        if (isPlayerInTrigger == true && Input.GetKeyDown(KeyCode.F))
        {
            GameObject memo = GameObject.FindGameObjectWithTag("Memo");
            memo.transform.GetChild(0).gameObject.SetActive(true);
            GameObject letterUI = GameObject.FindGameObjectWithTag(letter);
            letterUI.GetComponent<TextMeshPro>().color = new Color(255, 255, 255, 255);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {  
        if (other.gameObject.tag == "Player")
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPlayerInTrigger = false;
    }
}
