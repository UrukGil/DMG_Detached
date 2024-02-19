using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; // 移动速度
    public float changeDirectionTime = 2f; // 改变方向的时间间隔
    private Vector2 movement; // 移动方向
    private float timeToChangeDirection; // 改变方向的计时器
    private Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection(); // 初始时就随机选择一个方向
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 检查是否到了改变方向的时间
        if (Time.time >= timeToChangeDirection)
        {
            ChangeDirection();
        }
        UpdateAnimation();
    }

    void FixedUpdate()
    {
        // 应用移动
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void ChangeDirection()
    {
        // 生成一个新的随机方向
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        // 重置计时器
        timeToChangeDirection = Time.time + changeDirectionTime;
    }

    void UpdateAnimation()
    {
        float horizontalSpeed = movement.x;
        float verticalSpeed = movement.y;
        if (horizontalSpeed != 0)
        {
            //改动画的关键代码
            animator.SetFloat("horizontalSpeed", horizontalSpeed);
            //animator.SetFloat("verticalSpeed", 0);
        }
        if (verticalSpeed != 0)
        {
            //animator.SetFloat("horizontalSpeed", 0);
            animator.SetFloat("verticalSpeed", verticalSpeed);
        }
        //切换跑步
        Vector2 dir = new Vector2(horizontalSpeed, verticalSpeed);
        //改变参数来改动画
        animator.SetFloat("speed", dir.magnitude);

        //改变刚体速度
        GetComponent<Rigidbody2D>().velocity = dir * moveSpeed;
    }
}
