using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomBackground : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 17)
        {
            int randomNum = Random.Range(1, 2);
            //print(randomNum);
            if (randomNum == 1)
            {
                GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("Template1_1", typeof(Sprite)) as Sprite;
            }
            //else if (randomNum == 2)
            //{
            //    GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("2", typeof(Sprite)) as Sprite;
            //}
            //else if (randomNum == 3)
            //{
            //    GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("3", typeof(Sprite)) as Sprite;
            //}
            //else if (randomNum == 4)
            //{
            //    GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("4", typeof(Sprite)) as Sprite;
            //}
        }
        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            int randomNum = Random.Range(1, 7);
            //print(randomNum);
            if (randomNum == 1)
            {
                GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("Template2_1", typeof(Sprite)) as Sprite;
            }
            else if (randomNum == 2)
            {
                GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("Template2_2", typeof(Sprite)) as Sprite;
            }
            else if (randomNum == 3)
            {
                GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("Template2_3", typeof(Sprite)) as Sprite;
            }
            else if (randomNum == 4)
            {
                GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("Template2_4", typeof(Sprite)) as Sprite;
            }
            else if (randomNum == 5)
            {
                GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("Template2_5", typeof(Sprite)) as Sprite;
            }
            else if (randomNum == 6)
            {
                GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("Template2_6", typeof(Sprite)) as Sprite;
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 19)
        {
            int randomNum = Random.Range(1, 3);
            //print(randomNum);
            if (randomNum == 1)
            {
                GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("Template3_1", typeof(Sprite)) as Sprite;
            }
            else if (randomNum == 2)
            {
                GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("Template3_2", typeof(Sprite)) as Sprite;
            }
            //else if (randomNum == 3)
            //{
            //    GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("3", typeof(Sprite)) as Sprite;
            //}
            //else if (randomNum == 4)
            //{
            //    GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("4", typeof(Sprite)) as Sprite;
            //}
        }
        if (SceneManager.GetActiveScene().buildIndex == 20)
        {
            int randomNum = Random.Range(1, 2);
            //print(randomNum);
            if (randomNum == 1)
            {
                GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("Template4_1", typeof(Sprite)) as Sprite;
            }
            //else if (randomNum == 2)
            //{
            //    GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("2", typeof(Sprite)) as Sprite;
            //}
            //else if (randomNum == 3)
            //{
            //    GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("3", typeof(Sprite)) as Sprite;
            //}
            //else if (randomNum == 4)
            //{
            //    GameObject.FindWithTag("BG").GetComponent<SpriteRenderer>().sprite = Resources.Load("4", typeof(Sprite)) as Sprite;
            //}
        }
    }
}
