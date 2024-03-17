using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 0.3f; // 角色移动速度
    Animator animator;
    Rigidbody2D rb;
    AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("Step") != null)
        {
            audioSource = GameObject.FindWithTag("Step").GetComponent<AudioSource>();
        }
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
        float speed = dir.magnitude;
        animator.SetFloat("speed", speed);
        if (audioSource != null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 19 && speed != 0)
            {
                PlayFootstepLightSound();
            }
            if (SceneManager.GetActiveScene().buildIndex == 20 && speed != 0)
            {
                PlayFootstepHeavySound();
            }
            if (speed == 0)
            {
                audioSource.Stop();
            }
        }
        //改变刚体速度
        rb.velocity = dir * moveSpeed;
    }

    void PlayFootstepLightSound()
    {
        // 播放脚步声音效
        if (!audioSource.isPlaying)
        {
            // 随机选择一个脚步声音效
            AudioClip footstepSound = Resources.Load<AudioClip>("Light_Step");
            audioSource.clip = footstepSound;
            audioSource.Play();
        }
    }
    void PlayFootstepHeavySound()
    {
        // 播放脚步声音效
        if (!audioSource.isPlaying)
        {
            // 随机选择一个脚步声音效
            AudioClip footstepSound = Resources.Load<AudioClip>("Heavy_Step");
            audioSource.clip = footstepSound;
            audioSource.Play();
        }
    }
}
