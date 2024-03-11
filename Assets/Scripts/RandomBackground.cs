using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackground : MonoBehaviour
{
    private void Awake()
    {
        int randomNum = Random.Range(1, 5);
        //print(randomNum);
        if (randomNum == 1)
        {
            GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("1", typeof(Sprite)) as Sprite;
        }
        else if (randomNum == 2)
        {
            GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("2", typeof(Sprite)) as Sprite;
        }
        else if (randomNum == 3)
        {
            GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("3", typeof(Sprite)) as Sprite;
        }
        else if (randomNum == 4)
        {
            GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("4", typeof(Sprite)) as Sprite;
        }
    }
}
