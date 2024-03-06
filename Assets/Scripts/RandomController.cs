using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomController : MonoBehaviour
{
    [SerializeField] bool isRandomTurnedOn = false;
    // Start is called before the first frame update
    void Update()
    {
        if (isRandomTurnedOn)
        {
            EnterTrigger[] enterTriggers = GameObject.FindObjectsOfType<EnterTrigger>();
            foreach (EnterTrigger enterTrigger in enterTriggers)
            {
                enterTrigger.isRandomTurnedOn = true;
            }
        }
        else
        {
            EnterTrigger[] enterTriggers = GameObject.FindObjectsOfType<EnterTrigger>();
            foreach (EnterTrigger enterTrigger in enterTriggers)
            {
                enterTrigger.isRandomTurnedOn = false;
            }
        }
    }
}
