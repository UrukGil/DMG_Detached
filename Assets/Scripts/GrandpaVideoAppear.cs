using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GrandpaVideoAppear : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private int count = 0;
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
            if (isVideoEnd && count == 0)
            {
                count++;
                transform.GetChild(0).gameObject.SetActive(false);
                StartCoroutine(GrandpaAppear());
            }
        }
    }

    void OnVideoEnd(VideoPlayer videoPlayer)
    {
        isVideoEnd = true;
    }

    IEnumerator GrandpaAppear()
    {
        //Disappear
        GameObject.FindWithTag("Officer").SetActive(false);
        GameObject.FindWithTag("DarkSprite").SetActive(false);
        //Rupert to Door
        // Camera Lock
        yield return new WaitForSeconds(1f);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraMover>().player = GameObject.FindWithTag("Player");
        // move grandpa to door
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("horizontalSpeed", 0);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("verticalSpeed", -1);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("speed", 1);
        float time = 2f;
        while (time >= 0)
        {

            GameObject.FindWithTag("Player").GetComponent<Mover>().enabled = false;
            yield return new WaitForFixedUpdate();
            time -= Time.deltaTime;
            // 根据输入计算移动的方向和距离
            Vector2 movement = new Vector2(0, -1) * 0.3f * Time.deltaTime;

            // 移动角色
            GameObject.FindWithTag("Player").transform.Translate(movement);
        }
        GameObject.FindWithTag("Player").GetComponent<Mover>().enabled = true;
        PositionManager.instance.nextSpawnPoint = new Vector2(5.15f, -0.9f);
        //Enter Level 3
        //Done
        SceneManager.LoadScene(19);
        BGMController.Instance.ChangeBGM(Resources.Load<AudioClip>("Wind"));
    }
}
