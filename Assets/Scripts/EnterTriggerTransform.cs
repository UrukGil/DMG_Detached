using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTriggerTransform : MonoBehaviour
{
    Sprite bg1;
    Sprite bg2;
    Sprite bg3;
    Sprite bg4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindWithTag("Player").transform.position = new Vector3(0, -1.4f, 0);
        }

        bg1 = Resources.Load("1", typeof(Sprite)) as Sprite;
        bg2 = Resources.Load("2", typeof(Sprite)) as Sprite;
        bg3 = Resources.Load("3", typeof(Sprite)) as Sprite;
        bg4 = Resources.Load("4", typeof(Sprite)) as Sprite;
        int randomNum = Random.Range(1, 5);
        print(randomNum);
        if (randomNum == 1)
        {
            GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = bg1;
        }
        else if (randomNum == 2)
        {
            GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = bg2;
        }
        else if (randomNum == 3)
        {
            GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = bg3;
        }
        else if (randomNum == 4)
        {
            GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = bg4;
        }
    }
}
