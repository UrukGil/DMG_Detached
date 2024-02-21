using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTrigger : MonoBehaviour
{
    [SerializeField] int sceneIndex = 0;
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

            SceneManager.LoadScene(sceneIndex);
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
    }
}
