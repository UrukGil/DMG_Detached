using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPlayerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("InnerWorld").GetComponent<DialogueManager>().m_hasTalked == true)
        {
            gameObject.SetActive(false);
        }
        if (GetComponent<DialogueManager>().m_hasTalked == true)
        {
            //Done
            SceneManager.LoadScene(2);
            GameManager.Instance.RemoveItem("ControlPlayer");
        }
    }
}
