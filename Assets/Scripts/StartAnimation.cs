using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartAnimation : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private bool isVideoEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    private void Update()
    {
        if (isVideoEnd)
        {
            //Done
            SceneManager.LoadScene(2);
            if (BGMController.Instance != null)
            {
                BGMController.Instance.ChangeBGM(Resources.Load<AudioClip>("Level1"));
                BGMController.Instance.GetComponent<AudioSource>().Play();
            }
        }
    }
    void OnVideoEnd(VideoPlayer videoPlayer)
    {
        isVideoEnd = true;
    }
}
