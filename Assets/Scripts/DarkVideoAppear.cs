using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DarkVideoAppear : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public bool canPlay = false;
    private bool isVideoEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay == true)
        {
            // Stop player
            if (videoPlayer.isPlaying)
            {
                GameObject.FindWithTag("Player").GetComponent<Mover>().enabled = false;
                GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("horizontalSpeed", 0);
                GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("verticalSpeed", 0);
                GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("speed", 0);
            }
            // play video
            transform.GetChild(0).gameObject.GetComponent<VideoPlayer>().Play();
            if (isVideoEnd)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                //Rupert's Monologue
                GameObject.FindWithTag("Player").transform.GetChild(5).gameObject.SetActive(true);
                GameObject.FindWithTag("Player").transform.GetChild(5).GetComponent<DialogueManager>().m_canTalk = true;
                GameManager.Instance.RemoveItem("Virus2");
            }
        }
    }

    void OnVideoEnd(VideoPlayer videoPlayer)
    {
        isVideoEnd = true;
    }
}
