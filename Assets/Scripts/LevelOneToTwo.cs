using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LevelOneToTwo : MonoBehaviour
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
        if ( canPlay == true)
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
                StartCoroutine(Level1ToLevel2());
            }
        }
    }

    void OnVideoEnd(VideoPlayer videoPlayer)
    {
        isVideoEnd = true;
    }

    IEnumerator Level1ToLevel2()
    {
        while (GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize >= 0.01)
        {
            yield return new WaitForSeconds(0.01f);
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize -= 0.01f;
        }
        //Done
        SceneManager.LoadScene(18);//放在ani脚本里
        BGMController.Instance.ChangeBGM(Resources.Load<AudioClip>("Inner"));
    }
}
