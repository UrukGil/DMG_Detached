using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterTrigger : MonoBehaviour
{
    [SerializeField] int sceneIndex = 0;
    [SerializeField] bool playerIsInTrigger = false;
    [SerializeField] bool hasExactIndex = false;
    public Vector2 spawnPointInNextScene;
    [SerializeField] Dictionary<int, Vector2> spawnPointDictionary = new Dictionary<int, Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        spawnPointDictionary.Add(3, new Vector2(0, -0.5310215f));
        spawnPointDictionary.Add(4, new Vector2(0, -0.4613751f));
        spawnPointDictionary.Add(5, new Vector2(0, -0.4926267f));
        spawnPointDictionary.Add(6, new Vector2(0, -0.7744917f));
        if (!hasExactIndex)
        {
            sceneIndex = Random.Range(3, 7);
            spawnPointInNextScene = spawnPointDictionary[sceneIndex];
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (playerIsInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            PositionManager.instance.SetSpawnPoint(spawnPointInNextScene);
            //GameManager.Instance.timerKit = GameObject.FindWithTag("Timer").GetComponent<Timer>();
            SceneManager.LoadScene(sceneIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerIsInTrigger = false;
    }
}
