using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    // Variables to save
    public float timer;
    public int[] inventory;

    // Keys for PlayerPrefs
    private const string TIMER_KEY = "Timer";
    private const string INVENTORY_KEY = "Inventory";

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of GameStateManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // This object won't be destroyed when loading new scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    // Save game state
    public void SaveGameState()
    {
        PlayerPrefs.SetFloat(TIMER_KEY, timer);
        // Save inventory as a string (you might need a better serialization method for more complex data)
        string inventoryString = string.Join(",", inventory);
        PlayerPrefs.SetString(INVENTORY_KEY, inventoryString);
        PlayerPrefs.Save(); // Save the data immediately
    }

    // Load game state
    public void LoadGameState()
    {
        timer = PlayerPrefs.GetFloat(TIMER_KEY);
        // Load inventory as a string and convert back to array
        string inventoryString = PlayerPrefs.GetString(INVENTORY_KEY);
        string[] inventoryArray = inventoryString.Split(',');
        inventory = new int[inventoryArray.Length];
        for (int i = 0; i < inventoryArray.Length; i++)
        {
            inventory[i] = int.Parse(inventoryArray[i]);
        }
    }
}
