using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 0.3f; // 角色移动速度
    Animator animator;
    Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpdateAnimation();
    }

    private void Move()
    {
        // 使用Input.GetAxis获取水平和垂直方向的输入（-1到1之间的值）
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 根据输入计算移动的方向和距离
        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

        // 移动角色
        transform.Translate(movement);
    }

    private void UpdateAnimation()
    {
        float horizontalSpeed = Input.GetAxisRaw("Horizontal");
        float verticalSpeed = Input.GetAxisRaw("Vertical");
        if (horizontalSpeed != 0)
        {
            //改动画的关键代码
            animator.SetFloat("horizontalSpeed", horizontalSpeed);
            animator.SetFloat("verticalSpeed", 0);
        }
        if (verticalSpeed != 0)
        {
            animator.SetFloat("horizontalSpeed", 0);
            animator.SetFloat("verticalSpeed", verticalSpeed);
        }
        //切换跑步
        Vector2 dir = new Vector2(horizontalSpeed, verticalSpeed);
        //改变参数来改动画
        animator.SetFloat("speed", dir.magnitude);

        //改变刚体速度
        rb.velocity = dir * moveSpeed;
    }
}
