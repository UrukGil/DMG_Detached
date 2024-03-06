using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 引入UI命名空间


public class ComputerImage : MonoBehaviour
{
    [SerializeField] int sceneIndex = 0;
    [SerializeField] bool playerIsInTrigger = false;
    private GameObject Magic;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindObjectOfType<DialogueManager>() != null)
        {
            if (GameObject.FindObjectOfType<DialogueManager>().m_hasTalked == true)
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }

        GameObject ComputerImage = GameObject.FindGameObjectWithTag("ComputerImage");
        Magic = GameObject.FindWithTag("Player");
        Vector2 playerPos = Magic.transform.position;
        ComputerImage.transform.GetChild(0).position = new Vector2(playerPos.x, playerPos.y);
        if (playerIsInTrigger)
        {
            ComputerImage.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            ComputerImage.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerIsInTrigger = false;
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}


