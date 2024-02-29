using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevents the game manager from being destroyed.
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Ensures there's only one instance.
        }
    }

    // Player's items - Using a list to store string letters.
    public List<string> playerItems = new List<string>();
    public List<GameObject> gameObjectsList = new List<GameObject>();
    //public List<string> stringList;
    // Timer
    public float timer = 60f;
    public float timeLeft = 60f;
    public bool timerIsRunning = false;
    public Dictionary<string, GameObject> gameObjectsDict = new Dictionary<string, GameObject>();
    public Timer timerKit;
    private void Start()
    {
        if (GameObject.FindWithTag("Timer") != null){
            timerKit = GameObject.FindWithTag("Timer").GetComponent<Timer>();
        }
        
    }
    private void Update()
    {   
        if (GameObject.FindWithTag("Timer") != null){
            timerKit = GameObject.FindWithTag("Timer").GetComponent<Timer>();
        }
        // Timer Update
        // if (timerIsRunning)
        // {
        //     timer += Time.deltaTime;
        // }

    }

    // Method to start the timer
    // public void StartTimer()
    // {
    //     timerIsRunning = true;
    // }

    // Method to stop the timer and get the elapsed time
    // public float StopTimer()
    // {
    //     timerIsRunning = false;
    //     return timer; // Returns the current time value
    // }
    bool CheckIfStringsInList(params string[] strings)
    {
        // 使用 LINQ 查询，检查每个字符串是否在列表中
        foreach (string str in strings)
        {
            if (!playerItems.Contains(str))
            {
                return false; // 如果有任何一个字符串不在列表中，返回 false
            }
        }
        return true; // 如果所有字符串都在列表中，返回 true
    }
    public float GetTime()
    {
        timeLeft = timerKit.GetLeftTime();

        return timeLeft;
    }

    public float LoadTime()
    {
        return timer;
    }

    public void SaveTime()
    {
        timeLeft = GetTime();
        timer = timeLeft;
        // Debug.Log("Time left2: " + timeLeft);
    }

    // Add item to the player's inventory
    public void AddItem(string item)
    {
        playerItems.Add(item);
        StartCoroutine(CheckPhoneOpen());
    }

    public void clear(){
        playerItems.Clear();
    }

    IEnumerator CheckPhoneOpen()
    {

        string string1 = "Vegetable";
        string string2 = "Magazine";
        string string3 = "Wine";
        bool allStringsInList = CheckIfStringsInList(string1, string2, string3);
        GameObject dialogue = GameObject.FindGameObjectWithTag("Dialogue");
        if (allStringsInList)
        {
            yield return new WaitForSeconds(4f);
            GameObject.FindObjectOfType<MemoManager>().CloseMemo();
            yield return new WaitForSeconds(1f);
            dialogue.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    // Remove item from the player's inventory
    public bool RemoveItem(string item)
    {
        return playerItems.Remove(item);
    }

    // Get the current list of items
    public List<string> GetItems()
    {
        return playerItems;
    }

    public void AddGameObjectToList(GameObject obj)
    {
        if (!gameObjectsList.Contains(obj))
        {
            gameObjectsList.Add(obj);
        }
    }

    public void RemoveGameObjectFromList(GameObject obj)
    {
        if (gameObjectsList.Contains(obj))
        {
            gameObjectsList.Remove(obj);
        }
    }

    public void AddGameObjectToDict(string key, GameObject obj)
    {
        if (!gameObjectsDict.ContainsKey(key))
        {
            gameObjectsDict.Add(key, obj);
        }
    }

    public bool RemoveGameObjectFromDict(string key)
    {
        return gameObjectsDict.Remove(key);
    }

    public GameObject GetGameObjectFromDict(string key)
    {
        if (gameObjectsDict.ContainsKey(key))
        {
            return gameObjectsDict[key];
        }
        return null; // Return null if the object is not found
    }
    
    // Reset Timer
    public void ResetTimer()
    {
        timer = 0f;
    }
}
