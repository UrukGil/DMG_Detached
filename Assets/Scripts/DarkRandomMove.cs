using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRandomMove : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 movementDirection;
    private Vector2 newMovementDirection;

    // 在开始时随机选择一个方向
    void Start()
    {
    }

    // 每帧更新人物位置
    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    // 碰到障碍物时，选择一个新的移动方向
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        Vector2 reflectDirection = Vector2.Reflect(movementDirection, normal).normalized;
        movementDirection = (reflectDirection + Random.insideUnitCircle.normalized).normalized;
        
    }


}
