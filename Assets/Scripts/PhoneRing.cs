using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneRing : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(StartRing());
    }

    IEnumerator StartRing()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Ring", true);
        GameObject.FindWithTag("Player").transform.GetChild(2).gameObject.SetActive(true);
        GameObject.FindWithTag("Player").transform.GetChild(2).GetComponent<DialogueManager>().m_canTalk = true;
    }
}
