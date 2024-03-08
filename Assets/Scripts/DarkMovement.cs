using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMovement : MonoBehaviour
{
    public Transform[] points; // 存放路径点
    public float speed = 5f;
    private int currentIndex = 0;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (points.Length > 0)
        {
            transform.position = points[0].position; // 开始时角色位于第一个点
        }
    }

    void Update()
    {
        if (currentIndex < points.Length)
        {
            MoveTowardsPoint(points[currentIndex].position);
        }
        else
        {
            // 到达最后一个点后的逻辑，例如循环或停止
        }
    }

    void MoveTowardsPoint(Vector2 target)
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        Vector2 direction = (target - (Vector2)transform.position).normalized;

        // 更新Animator参数以匹配动画
        animator.SetFloat("horizontalSpeed", direction.x);
        animator.SetFloat("verticalSpeed", direction.y);

        //切换跑步
        Vector2 dir = new Vector2(direction.x, direction.y);
        //改变参数来改动画
        animator.SetFloat("speed", dir.magnitude);

        //改变刚体速度
        GetComponent<Rigidbody2D>().velocity = dir * speed;

        transform.position = newPosition;

        if (Vector2.Distance(transform.position, target) < 0.1f) // 如果角色非常接近当前目标点
        {
            currentIndex++; // 切换到下一个点
        }
    }
}
