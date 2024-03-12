using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTriggerTransform : MonoBehaviour
{
    [SerializeField] bool playerIsInTrigger = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            //print("J你来");
            GameObject.FindWithTag("Player").transform.position = new Vector3(0, -1.4f, 0);
            int randomNum = Random.Range(1, 19);
            //print(randomNum);
            while (GameManager.Instance.levelThreeList.Contains(randomNum) && GameManager.Instance.levelThreeList.Count != 18)
            {
                randomNum = Random.Range(1, 19);
            }
            if (GameManager.Instance.levelThreeList.Count == 18)
            {
                print("GameOver");
                // GameOver
            }
            if (!GameManager.Instance.levelThreeList.Contains(randomNum))
            {
                GameManager.Instance.levelThreeList.Add(randomNum);
                GameObject[] BGs = GameObject.FindGameObjectsWithTag("BG");
                foreach (GameObject BG in BGs)
                {
                    if (BG.transform.GetChild(0).GetChild(0).name == "Background" + randomNum.ToString())
                    {
                        print("true");
                        BG.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        BG.transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsInTrigger = false;
    }

}
