using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MemoVideoAppear : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private bool isVideoEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Player").transform.GetChild(3).gameObject.GetComponent<DialogueManager>().m_hasTalked == true)
        {
            transform.GetChild(0).gameObject.GetComponent<VideoPlayer>().Play();
            if (isVideoEnd)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindWithTag("Player").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.FindWithTag("Player").transform.GetChild(4).GetComponent<DialogueManager>().m_canTalk = true;
            }
        }
    }

    void OnVideoEnd(VideoPlayer videoPlayer)
    {
        isVideoEnd = true;
    }
}
