using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterTrigger : MonoBehaviour
{
    [SerializeField] int sceneIndex = 0;
    [SerializeField] bool playerIsInTrigger = false;
    public bool isRandomTurnedOn = false;
    [SerializeField] bool isRandomRoom = false;
    [SerializeField] bool isRandomCorridor = false;
    [SerializeField] bool isRandomRoomInLevel2 = false;
    [SerializeField] bool isRandomCorridorInLevel2 = false;
    public Vector2 spawnPointInNextScene;
    [SerializeField] Dictionary<int, Vector2> spawnPointDictionary = new Dictionary<int, Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        spawnPointDictionary.Add(0, new Vector2(1.4668f, -0.502f));
        spawnPointDictionary.Add(1, new Vector2(1.0334f, 0.4889f));
        spawnPointDictionary.Add(2, new Vector2(1.364774f, -0.4488968f));
        spawnPointDictionary.Add(3, new Vector2(0, -0.5310215f));
        spawnPointDictionary.Add(4, new Vector2(0, -0.4613751f));
        spawnPointDictionary.Add(5, new Vector2(0, -0.4926267f));
        spawnPointDictionary.Add(6, new Vector2(0, -0.7744917f));
        spawnPointDictionary.Add(7, new Vector2(1.4668f, -0.502f));
        spawnPointDictionary.Add(8, new Vector2(1.0334f, 0.4889f));
        spawnPointDictionary.Add(9, new Vector2(1.364774f, -0.4488968f));
        spawnPointDictionary.Add(10, new Vector2(0, -0.5310215f));
        spawnPointDictionary.Add(11, new Vector2(0, -0.4613751f));
        spawnPointDictionary.Add(12, new Vector2(0, -0.4926267f));
        spawnPointDictionary.Add(13, new Vector2(0, -0.7744917f));
    }
    
    // Update is called once per frame
    void Update()
    {
       
        if (isRandomTurnedOn)
        {
            if (isRandomRoom)
            {
                sceneIndex = Random.Range(3, 7);
                spawnPointInNextScene = spawnPointDictionary[sceneIndex];
            }
            if (isRandomCorridor)
            {
                sceneIndex = Random.Range(0, 3);
                spawnPointInNextScene = spawnPointDictionary[sceneIndex];
            }
            if (isRandomRoomInLevel2)
            {
                sceneIndex = Random.Range(10, 14);
                spawnPointInNextScene = spawnPointDictionary[sceneIndex];
            }
            if (isRandomCorridorInLevel2)
            {
                sceneIndex = Random.Range(7, 10);
                spawnPointInNextScene = spawnPointDictionary[sceneIndex];
            }
        }
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
