using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MemoVideoAppear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Player").transform.GetChild(3).gameObject.GetComponent<DialogueManager>().m_hasTalked == true)
        {
            GetComponent<VideoPlayer>().enabled = true;
        }
        if (GetComponent<VideoPlayer>().enabled == true)
        {
            if (GetComponent<VideoPlayer>().isPlaying == false)
            {
                GetComponent<VideoPlayer>().Stop();
            }
        }
    }
}
