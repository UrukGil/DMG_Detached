using UnityEngine;
using UnityEngine.UI; // 引入UI命名空间
using UnityEngine.SceneManagement; // 引入场景管理命名空间

public class Timer: MonoBehaviour
{
    public Slider progressBar; // 引用UI进度条
    public float duration = 180f; // 计时器的持续时间
    private float timeLeft; // 剩余时间
    public bool hasStarted = false;
    public bool isCounting = true;

    void Start()
    {
        // print("duration "+duration);
        timeLeft = GameManager.Instance.LoadTime();
        if (progressBar == null)
        {
            Debug.LogError("Progress bar slider is not assigned!");
            return;
        }
        if (timeLeft < duration && timeLeft > 0)
        {
            // print("here2");
            timeLeft = GameManager.Instance.LoadTime();
        }
        else
        {
            timeLeft = duration;
            // print("here1");
            progressBar.value = 1; // 初始化进度条值为100%
        }
        //print("timeleft "+timeLeft);
        
    }

    void Update()
    {
        if (timeLeft <= 0f)
        {
            //endgame
            SceneManager.LoadScene("GameOver");
            BGMController.Instance.GetComponent<AudioSource>().Stop();
        }
        if (timeLeft > 0)
        {
            if (isCounting && hasStarted)
            {
                // 更新剩余时间
                timeLeft -= Time.deltaTime;
                GameManager.Instance.SaveTime();
                // 计算剩余时间的百分比，并更新进度条的值
                progressBar.value = timeLeft / duration;
            }
        }
        else
        {
            // 确保进度条值为0
            progressBar.value = 0;
            // 可选：计时器结束后的逻辑
        }
    }

    public float GetLeftTime()
    {
        return timeLeft;
    }
}
