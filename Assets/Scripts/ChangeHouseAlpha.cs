using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHouseAlpha : MonoBehaviour
{
    float speed = 0.2f;
    SpriteRenderer rend = null;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = Mathf.PingPong(Time.time * speed, 1f); // 使用PingPong函数来让透明度在0到1之间循环变化
        Color color = rend.material.color;
        color.a = alpha;
        rend.material.color = color;
    }
}
