using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DarkMovement : MonoBehaviour
{
    public Transform[] points; // 存放路径点
    public float speed = 5f;
    private int currentIndex = 0;
    private Animator animator;
    public float darkEnterBias = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (points.Length > 0)
        {
            transform.position = points[0].position; // 开始时角色位于第一个点
        }
        //for (int i = 0; i < GameObject.FindWithTag("WayPoint").transform.childCount; i++)
        //{
        //    points[i] = GameObject.FindWithTag("WayPoint").transform.GetChild(i).transform;
        //}
    }

    void Update()
    {
        if (currentIndex < points.Length)
        {
            MoveTowardsPoint(points[currentIndex].position);
        }
        else
        {
            //MoveTowardsPoint(points[0].position);
            // 到达最后一个点后的逻辑，例如循环或停止
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float randomNum = Random.Range(0, 1f);
        if (collision.gameObject.tag == "Player" && GameManager.Instance.darkMissedTime >= 5 && randomNum > 0.9f){
                //print("You got me");
                
                GameManager.Instance.caughtDark = true;
                //黑影消失
                //this.gameObject.SetActive(false);
                
                
        }
        else{
            if (collision.gameObject.tag == "Player")
            {
                //print("哈哈");
                GameManager.Instance.darkMissedTime += 1;
                currentIndex++;
                if (currentIndex >= points.Length)
                {
                    currentIndex = 0;
                }
                transform.position = points[currentIndex].position;
            }
        }
        
    }


    void MoveTowardsPoint(Vector2 target)
    {
        if (points.Length == 0) return;

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
            if (currentIndex >= points.Length)
            {
                currentIndex = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (points != null)
        {
            Gizmos.color = new Color(0, 0, 0);
            if (points.Length != 0)
            {
                foreach (Transform tempTransform in points)
                {
                    Gizmos.DrawWireSphere(tempTransform.position, 0.1f);
                }
            }
            for (int i = 0; i < points.Length; i++)
            {
                if (i == points.Length - 1)
                {
                    Gizmos.DrawLine(points[i].position, points[0].position);
                }
                else
                {
                    Gizmos.DrawLine(points[i].position, points[i + 1].position);
                }
            }
        }

    }
}
