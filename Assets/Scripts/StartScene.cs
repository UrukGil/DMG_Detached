using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    // 这个变量用于指向你想要关闭的对象
    public GameObject gameStartUI;

    // 这个方法会被绑定到按钮的点击事件上
    public void StartGame()
    {
        SceneManager.LoadScene(0);
        BGMController.Instance.ChangeBGM(Resources.Load<AudioClip>("Level1"));
        BGMController.Instance.GetComponent<AudioSource>().Play();
    }
}
