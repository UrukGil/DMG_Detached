using UnityEngine;

public class BGMController : MonoBehaviour
{
    private static BGMController instance = null;
    public static BGMController Instance
    {
        get { return instance; }
    }

    private AudioSource audioSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>(); // 获取AudioSource组件
    }

    void Start()
    {
        audioSource.volume = 0.2f; // 播放背景音乐
    }
    // 用于更换背景音乐的方法
    public void ChangeBGM(AudioClip newClip)
    {
        if (audioSource.clip == newClip) return; // 如果新剪辑与当前剪辑相同，则不做更改

        audioSource.Stop(); // 停止当前音乐
        audioSource.clip = newClip; // 更换音乐剪辑
        audioSource.Play(); // 播放新音乐
    }

    // 其他控制背景音乐的代码可以放在这里
}