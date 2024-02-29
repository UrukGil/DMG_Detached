using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    // 这个变量用于指向你想要关闭的对象
    public GameObject gameOverUI;

    // 这个方法会被绑定到按钮的点击事件上
    public void BackToStartScene()
    {
        GameManager.Instance.playerItems.Clear();
        SceneManager.LoadScene("StartScene");
    }
}
