using System.Collections.Generic;
using UnityEngine;

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

    // Timer
    // private float timer = 0f;
    public bool timerIsRunning = false;
    public Dictionary<string, GameObject> gameObjectsDict = new Dictionary<string, GameObject>();

    private void Update()
    {
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

    // Add item to the player's inventory
    public void AddItem(string item)
    {
        playerItems.Add(item);
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
    // public void ResetTimer()
    // {
    //     timer = 0f;
    // }
}
