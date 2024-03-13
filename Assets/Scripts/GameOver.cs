using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    // 这个方法会被绑定到按钮的点击事件上
    public void BackToStartScene()
    {
        GameManager.Instance.clear();
        SceneManager.LoadScene("StartScene");
    }
}
