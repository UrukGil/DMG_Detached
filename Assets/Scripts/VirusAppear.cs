using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusAppear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VirusAppearFunc());
    }
    IEnumerator VirusAppearFunc()
    {
        yield return new WaitForSeconds(3f);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).GetComponent<DialogueManager>().m_canTalk = true;
    }
}
