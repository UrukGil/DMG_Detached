using UnityEngine;

public class PhoneClose : MonoBehaviour
{
    // 这个变量用于指向你想要关闭的对象
    public GameObject objectToClose;

    // 这个方法会被绑定到按钮的点击事件上
    public void CloseObject()
    {
        if (objectToClose != null)
        {
            // 设置对象为非激活（隐藏）
            objectToClose.SetActive(false);
        }
    }
}