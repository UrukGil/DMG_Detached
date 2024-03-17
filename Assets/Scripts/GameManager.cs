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
    private int count3 = 0;

    private int count4 = 0;
    private int count5 = 0;
    private int count6 = 0;
    private int count7 = 0;
    private int countInnerWorld = 0;

    private int playAnimation = 0;
    private int countExitInnerWorld = 0;
    private int countExitInnerWorld2 = 0;
    public GameObject dialogue;
    [SerializeField] GameObject phone = null;
    private bool hasStarted = false;
    public int darkSceneIndex = 8;
    public int currentSceneIndex = 0;
    public float darkEnterBias = 0f;
    public int darkMissedTime = 0;

    public bool caughtDark = false;
    public bool outOfMaze = false;
    public List<int> levelThreeList = new List<int>();
    
    private void Start()
    {
        if (GameObject.FindWithTag("Timer") != null){
            timerKit = GameObject.FindWithTag("Timer").GetComponent<Timer>();
        }
    }
    private void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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

        if (CheckIfStringsInList("Virus2") && SceneManager.GetActiveScene().buildIndex == 7 && countExitInnerWorld2 == 0)
        {
            countExitInnerWorld2 += 1;
            StartCoroutine(ExitInnerWorld2());
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
        if (GameObject.FindWithTag("Player") != null)
        {
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

        if (GameObject.FindWithTag("DarkParent") != null)
        {
            darkEnterBias = GameObject.FindWithTag("DarkParent").transform.GetChild(0).GetComponent<DarkMovement>().darkEnterBias;
            if (darkSceneIndex == SceneManager.GetActiveScene().buildIndex)
            {
                GameObject.FindWithTag("DarkParent").transform.GetChild(0).transform.gameObject.SetActive(true);
            }
            else
            {
                GameObject.FindWithTag("DarkParent").transform.GetChild(0).transform.gameObject.SetActive(false);
            }
        }

        if(GameObject.FindWithTag("Player") != null)
        {
            if(GameObject.FindWithTag("Player").transform.childCount >= 5){
                if(caughtDark == true)
                {
                    if(SceneManager.GetActiveScene().buildIndex == 19){
                        GameObject.FindWithTag("Player").transform.GetChild(6).gameObject.SetActive(true);
                        GameObject.FindWithTag("Player").transform.GetChild(6).GetComponent<DialogueManager>().m_canTalk = true;
                    }
                    //切回livingroom
                    
                    if(count4 == 0){
                        PositionManager.instance.SetSpawnPoint(new Vector2(0,-0.3f));
                        SceneManager.LoadScene(19);
                        count4 += 1;
                    }
                }
            }
            if(GameObject.FindWithTag("Player").transform.childCount >= 5 && count6 == 0)
            {
                if (GameObject.FindWithTag("Player").transform.GetChild(6).GetComponent<DialogueManager>().m_hasTalked == true)
                {
                    count6 += 1;
                    StartCoroutine(SophieAppear());
                }
            }
            if(GameObject.FindWithTag("Player").transform.childCount >= 6 && count7 == 0)
            {
                if (GameObject.FindWithTag("Player").transform.GetChild(7).GetComponent<DialogueManager>().m_hasTalked == true)
                {
                    //To level 3
                    count7 += 1;
                    StartCoroutine(EnterLevelThree());
                }
                //count7 += 1;
                //StartCoroutine(EnterLevelThree());
            }
        }
        
        if (outOfMaze == true && count5 == 0){
            count5 += 1;
            StartCoroutine(EnterInnerWorld3());
        }
    }

    IEnumerator EnterInnerWorld3()
    {
        GameObject.FindWithTag("Player").GetComponent<Mover>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("horizontalSpeed", 0);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("verticalSpeed", -1);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("speed", 0);
        while (GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize >= 0.01)
        {
            yield return new WaitForSeconds(0.01f);
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize -= 0.01f;
        }
        SceneManager.LoadScene(20);
        BGMController.Instance.ChangeBGM(Resources.Load<AudioClip>("Inner"));

    }
    IEnumerator SophieAppear()
    {
        //play Animation（one pic)
        yield return null;

        //Sophie Appear
        GameObject.FindWithTag("Sophie").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.FindWithTag("Player").transform.GetChild(7).gameObject.SetActive(true);
        GameObject.FindWithTag("Player").transform.GetChild(7).GetComponent<DialogueManager>().m_canTalk = true;
    }

    IEnumerator EnterLevelThree()
    {
        yield return null;
        //PlayerMovelock
        GameObject.FindWithTag("Player").GetComponent<Mover>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //Sophie to Kitchen
        GameObject.FindWithTag("Sophie").transform.GetChild(0).GetComponent<Animator>().SetFloat("horizontalSpeed", 0);
        GameObject.FindWithTag("Sophie").transform.GetChild(0).GetComponent<Animator>().SetFloat("verticalSpeed", 1);
        GameObject.FindWithTag("Sophie").transform.GetChild(0).GetComponent<Animator>().SetFloat("speed", 1);
        // Camera Lock
        GameObject.FindWithTag("MainCamera").GetComponent<CameraMover>().player = GameObject.FindWithTag("Sophie").transform.GetChild(0).gameObject;
        float time = 0.7f;
        while (time >= 0)
        {
            yield return new WaitForFixedUpdate();
            time -= Time.deltaTime;
            // 根据输入计算移动的方向和距离
            Vector2 movement = new Vector2(0, 1) * 0.3f * Time.deltaTime;

            // 移动角色
            GameObject.FindWithTag("Sophie").transform.Translate(movement);
        }
        GameObject.FindWithTag("Sophie").transform.GetChild(0).GetComponent<Animator>().SetFloat("horizontalSpeed", 1);
        GameObject.FindWithTag("Sophie").transform.GetChild(0).GetComponent<Animator>().SetFloat("verticalSpeed", 0);
        GameObject.FindWithTag("Sophie").transform.GetChild(0).GetComponent<Animator>().SetFloat("speed", 1);
        time = 3.1f;
        while (time >= 0)
        {
            yield return new WaitForFixedUpdate();
            time -= Time.deltaTime;
            // 根据输入计算移动的方向和距离
            Vector2 movement = new Vector2(1, 0) * 0.3f * Time.deltaTime;

            // 移动角色
            GameObject.FindWithTag("Sophie").transform.GetChild(0).Translate(movement);
        }
        GameObject.FindWithTag("Sophie").transform.GetChild(0).GetComponent<Animator>().SetFloat("horizontalSpeed", 0);
        GameObject.FindWithTag("Sophie").transform.GetChild(0).GetComponent<Animator>().SetFloat("verticalSpeed", 1);
        GameObject.FindWithTag("Sophie").transform.GetChild(0).GetComponent<Animator>().SetFloat("speed", 1);
        time = 4.3f;
        while (time >= 0)
        {
            yield return new WaitForFixedUpdate();
            time -= Time.deltaTime;
            // 根据输入计算移动的方向和距离
            Vector2 movement = new Vector2(0, 1) * 0.3f * Time.deltaTime;

            // 移动角色
            GameObject.FindWithTag("Sophie").transform.Translate(movement);
        }
        GameObject.FindWithTag("Sophie").transform.GetChild(0).GetComponent<Animator>().SetFloat("horizontalSpeed", 0);
        GameObject.FindWithTag("Sophie").transform.GetChild(0).GetComponent<Animator>().SetFloat("verticalSpeed", 0);
        GameObject.FindWithTag("Sophie").transform.GetChild(0).GetComponent<Animator>().SetFloat("speed", 0);
        GameObject.FindWithTag("Sophie").transform.GetChild(0).gameObject.SetActive(false);
        //Animation
        //Rupert to Door
        // Camera Lock
        yield return new WaitForSeconds(1f);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraMover>().player = GameObject.FindWithTag("Player");
        // move grandpa to door
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("horizontalSpeed", 0);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("verticalSpeed", -1);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("speed", 1);
        time = 2f;
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
        PositionManager.instance.nextSpawnPoint = new Vector2(5.15f, -0.9f);
        //Enter Level 3
        SceneManager.LoadScene(21);
        BGMController.Instance.ChangeBGM(Resources.Load<AudioClip>("Level 3"));
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
        //GameObject.FindWithTag("Player").GetComponent<Mover>().enabled = true;
        //yield return new WaitForSeconds(2f);
        // play door

        // play headingout anime
        GameObject.FindWithTag("HeadingOut").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.FindWithTag("HeadingOut").transform.GetChild(0).transform.position = new Vector2(GameObject.FindWithTag("Player").transform.position.x, GameObject.FindWithTag("Player").transform.position.y);
        yield return new WaitForSeconds(3f);

        // play door
        // grandpa back
        GameObject.FindWithTag("HeadingOut").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("horizontalSpeed", 0);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("verticalSpeed", 1);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("speed", 1);

        time = 3.0f;
        while (time >= 0)
        {

            GameObject.FindWithTag("Player").GetComponent<Mover>().enabled = false;
            yield return new WaitForFixedUpdate();
            time -= Time.deltaTime;
            // 根据输入计算移动的方向和距离
            Vector2 movement = new Vector2(0, 1) * 0.3f * Time.deltaTime;

            // 移动角色
            GameObject.FindWithTag("Player").transform.Translate(movement);
        }
        //GameObject.FindWithTag("Player").GetComponent<Mover>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("horizontalSpeed", 0);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("verticalSpeed", -1);
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetFloat("speed", 0);
        //EnterInnerWorld
        yield return new WaitForSeconds(2f);
        while (GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize >= 0.01)
        {
            yield return new WaitForSeconds(0.01f);
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize -= 0.01f;
        }
        
        SceneManager.LoadScene(16);
        BGMController.Instance.ChangeBGM(Resources.Load<AudioClip>("Inner"));
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
    IEnumerator ExitInnerWorld2()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize = 0.01f;
        while (GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize <= 0.7f)
        {
            yield return new WaitForSeconds(0.01f);
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize += 0.01f;
        }
        yield return new WaitForSeconds(1f);
        //Rupert's Monologue
        GameObject.FindWithTag("Player").transform.GetChild(5).gameObject.SetActive(true);
        GameObject.FindWithTag("Player").transform.GetChild(5).GetComponent<DialogueManager>().m_canTalk = true;
        GameManager.Instance.RemoveItem("Virus2");
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
        darkMissedTime = 0;
        count = 0;
        count2 = 0;
        count3 = 0;
        count4 = 0;
        count5 = 0;
        count6 = 0;
        count7 = 0;
        countInnerWorld = 0;
        playAnimation = 0;
        countExitInnerWorld = 0;
        countExitInnerWorld2 = 0;
        darkEnterBias = 0f;
        caughtDark = false;
        outOfMaze = false;
    }

    IEnumerator CheckEverything()
    {

        string string1 = "Vegetable";
        string string2 = "Magazine";
        string string3 = "Wine";
        string string4 = "Photo";
        string string5 = "Newspaper";
        string string6 = "Birthday";
        string string7 = "All";


        if (CheckIfStringsInList(string1, string2, string3) && count == 0)
        {
            count = 1;
            yield return new WaitForSeconds(6f);
            dialogue.transform.GetChild(2).gameObject.SetActive(true);
            print(dialogue.transform.GetChild(2).gameObject.activeSelf);
            yield return new WaitForSeconds(6f);
            dialogue.transform.GetChild(2).gameObject.SetActive(false);
            yield return new WaitForSeconds(1f);
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

        if (CheckIfStringsInList(string7) && count3 == 0)//第一关和第二关过渡
        {
            //TO-DO: play animation

            //Enter Innerworld2
            count3 += 1;
            StartCoroutine(Level1ToLevel2());
        }
    }

    IEnumerator Level1ToLevel2()
    {
        yield return new WaitForSeconds(6f);
        while (GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize >= 0.01)
        {
            yield return new WaitForSeconds(0.01f);
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize -= 0.01f;
        }
        SceneManager.LoadScene(18);//放在ani脚本里
        BGMController.Instance.ChangeBGM(Resources.Load<AudioClip>("Inner"));
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

    // Reset Timer
    public void ResetTimer()
    {
        timer = 0f;
    }
}
