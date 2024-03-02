using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 引入UI命名空间


public class ComputerImage : MonoBehaviour
{
    [SerializeField] int sceneIndex = 0;
    [SerializeField] bool playerIsInTrigger = false;
    private GameObject Magic;
   

    public Vector2 spawnPointInNextScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject ComputerImage = GameObject.FindGameObjectWithTag("ComputerImage");
        Magic = GameObject.FindWithTag("Magic");
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
        if (other.gameObject.tag == "Magic")
        {
            playerIsInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerIsInTrigger = false;
    }
}


