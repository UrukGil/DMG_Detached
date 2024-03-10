using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ComputerVideoAppear : MonoBehaviour
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
        if (GameObject.FindObjectOfType<UsingComputer>().playerIsInTrigger)
        {
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
                StartCoroutine(SceneChange());
            }
        }
    }

    void OnVideoEnd(VideoPlayer videoPlayer)
    {
        isVideoEnd = true;
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
