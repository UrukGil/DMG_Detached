using UnityEngine;
using UnityEngine.UI; // 引入UI命名空间

public class ProgressBarTimer : MonoBehaviour
{
    public Slider progressBar; // 引用UI进度条
    public float duration = 10f; // 计时器的持续时间
    private float timeLeft; // 剩余时间

    void Start()
    {
        if (progressBar == null)
        {
            Debug.LogError("Progress bar slider is not assigned!");
            return;
        }

        timeLeft = duration;
        progressBar.value = 1; // 初始化进度条值为100%
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            // 更新剩余时间
            timeLeft -= Time.deltaTime;
            // 计算剩余时间的百分比，并更新进度条的值
            progressBar.value = timeLeft / duration;
        }
        else
        {
            // 确保进度条值为0
            progressBar.value = 0;
            // 可选：计时器结束后的逻辑
        }
    }
}
