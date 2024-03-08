using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEngine.SceneManagement;

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
    public float timer = 180f;
    public float timeLeft = 180f;
    public bool timerIsRunning = false;
    public Dictionary<string, GameObject> gameObjectsDict = new Dictionary<string, GameObject>();
    public Timer timerKit;
    public int memoClosedTimes = 0;

    private int count = 0;
    private int count2 = 0;
    private int countInnerWorld = 0;

    private int playAnimation = 0;
    private int countExitInnerWorld = 0;
    public GameObject dialogue;
    [SerializeField] GameObject phone = null;
    private bool hasStarted = false;
    private void Start()
    {
        if (GameObject.FindWithTag("Timer") != null){
            timerKit = GameObject.FindWithTag("Timer").GetComponent<Timer>();
        }
        
    }
    private void Update()
    {   
        if (GameObject.FindWithTag("Timer") != null)
        {
            timerKit = GameObject.FindWithTag("Timer").GetComponent<Timer>();
            timerKit.hasStarted = hasStarted;
        }
        dialogue = GameObject.FindGameObjectWithTag("Dialogue");
        string string1 = "Phone";
        if (CheckIfStringsInList(string1))
        {
            phone = GameObject.FindWithTag("Phone");
            if (phone != null)
            {
                phone.SetActive(false);
            }
        }
        if (CheckIfStringsInList("Virus") && SceneManager.GetActiveScene().buildIndex == 0 && countExitInnerWorld == 0)
        {
            countExitInnerWorld += 1;
            StartCoroutine(ExitInnerWorld());
            //print(SceneManager.GetActiveScene().buildIndex);
        }
        if (GameObject.FindWithTag("InnerWorld") != null)
        {
            if (GameObject.FindWithTag("InnerWorld").GetComponent<DialogueManager>().m_hasTalked == true && countInnerWorld == 0)
            {
                StartCoroutine(EnterInnerWorld());
                countInnerWorld += 1;
            }
        }
        if (GameObject.FindWithTag("Player").name == "Grandpa")
        {
            if (GameObject.FindWithTag("Player").transform.GetChild(4).GetComponent<DialogueManager>().m_hasTalked == true)
            {
                //StartCoroutine(ExitInnerWorld());
                hasStarted = true;
                //if (GameObject.FindWithTag("W").GetComponent<Animator>().GetCurrentAnimatorClipInfo)
            }
        }

    }

    IEnumerator EnterInnerWorld()
    {
        // WrtingAni start
        GameObject.FindWithTag("WritingAni").transform.GetChild(0).gameObject.SetActive(true);
        //PlayerMovelock
        GameObject.FindWithTag("Player").GetComponent<Mover>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        // close animation
        yield return new WaitForSeconds(3f);
        GameObject.FindWithTag("WritingAni").transform.GetChild(0).gameObject.SetActive(false);

        // move grandpa to door
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("horizontalSpeed", 0);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("verticalSpeed", -1);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("speed", 1);
        float time = 3.0f;
        while (time >= 0)
        {
            
            GameObject.FindWithTag("Player").GetComponent<Mover>().enabled = false;
            yield return new WaitForFixedUpdate();
            time -= Time.deltaTime;
            // 根据输入计算移动的方向和距离
            Vector2 movement = new Vector2(0, -1) * 0.3f * Time.deltaTime;

            // 移动角色
            GameObject.FindWithTag("Player").transform.Translate(movement);
        }

        GameObject.FindWithTag("Player").GetComponent<Mover>().enabled = true;
        yield return new WaitForSeconds(3f);
        // grandpa back
              

        //EnterInnerWorld
        while (GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize >= 0.01)
        {
            yield return new WaitForSeconds(0.01f);
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize -= 0.01f;
        }
        SceneManager.LoadScene(16);
    }

    IEnumerator ExitInnerWorld()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize = 0.01f;
        while (GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize <= 0.7f)
        {
            yield return new WaitForSeconds(0.01f);
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize += 0.01f;
        }
        yield return new WaitForSeconds(1f);
        GameObject.FindWithTag("Player").transform.GetChild(3).gameObject.SetActive(true);
        GameObject.FindWithTag("Player").transform.GetChild(3).GetComponent<DialogueManager>().m_canTalk = true;
        GameManager.Instance.RemoveItem("Virus");
    }
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
        StartCoroutine(CheckEverything());
    }

    public void clear(){
        playerItems.Clear();
        memoClosedTimes = 0;
    }

    IEnumerator CheckEverything()
    {

        string string1 = "Vegetable";
        string string2 = "Magazine";
        string string3 = "Wine";
        string string4 = "Photo";
        string string5 = "Newspaper";
        string string6 = "Birthday";


        if (CheckIfStringsInList(string1, string2, string3) && count == 0)
        {
            count = 1;
            yield return new WaitForSeconds(6f);
            dialogue.transform.GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(6f);
            dialogue.transform.GetChild(2).gameObject.SetActive(false);
            yield return new WaitForSeconds(2f);
            GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<DialogueManager>().m_canTalk = true;
        }
        
        if (CheckIfStringsInList(string1, string2, string3, string4, string5, string6) && count2 == 0)
        {
            yield return new WaitForSeconds(6f);
            //print("all collected");
            count2 = 1;
            GameObject.FindWithTag("Player").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<DialogueManager>().m_canTalk = true;
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
