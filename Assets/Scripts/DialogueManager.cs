using System.Collections;
using System.Collections.Generic;
//using DG.Tweening;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public SODialogue m_dialogueData = null;
    public GameObject m_pressSpaceUI = null;
    [SerializeField] public bool m_canTalk = false;
    public bool m_isTalking = false;
    public bool m_hasTalked = false;
    [SerializeField] bool m_isAutoStart = false;
    private GameObject m_dialogueCanvas = null;
    [SerializeField] DialogueUI m_dialogue = null;
    private GameObject m_player = null;
    [SerializeField] public string letter;
    [Header("是否是需要收集的物品？")]
    [SerializeField] public bool m_isMemoTrigger = false;
    [Header("是否是自动触发的对话？")]
    [SerializeField] public bool m_isDialogueTrigger = false;
    private GameObject player;
    private void Awake()
    {
        m_player = GameObject.FindWithTag("Player");
        m_dialogueCanvas = GameObject.FindWithTag("Dialogue");
        m_dialogue = m_dialogueCanvas.GetComponent<DialogueUI>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && m_dialogueData != null)
        {
            m_canTalk = true;
            if (!m_hasTalked && m_pressSpaceUI != null)
            {
                m_pressSpaceUI.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && m_dialogueData != null)
        {
            if (m_dialogue != null)
            {
                m_dialogue.m_dialoguePanel.SetActive(false);
                m_dialogue.m_dialogueOptionPanel.SetActive(false);
            }
            m_canTalk = false;
            m_isTalking = false;
            if (m_pressSpaceUI != null)
            {
                m_pressSpaceUI.SetActive(false);
            }
            if (letter == "K")
            {
                GetComponent<RandomMover>().enabled = true;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Animator>().enabled = true;
            }
        }
    }
    private void Update()
    {
        if (m_canTalk){
            if (GameManager.Instance.playerItems.Contains(letter))
            {
                m_hasTalked = true;
            }
        }
        if (!m_hasTalked && m_canTalk && (Input.GetKeyDown(KeyCode.Space)||m_isAutoStart) && m_dialogue.m_dialoguePanel.activeSelf == false)
        {
            StartDialogue();
            m_isTalking = true;
        }
        if (m_isTalking)
        {
            // m_player.transform.LookAt(transform);
            if (m_pressSpaceUI != null)
            {
                m_pressSpaceUI.SetActive(false);
            }
        }
        if (!m_hasTalked && m_canTalk && !m_isTalking)
        {
            if (m_pressSpaceUI != null)
            {
                m_pressSpaceUI.SetActive(true);
            }
        }
        if (m_dialogueData != null)
        {
            m_dialogueData.UpdateDialogueDictionary();
        }
    }
    private void StartDialogue()
    {
        m_dialogue.m_dialogueManager = this;
        StartCoroutine(ChangeDialoguePosition());
        if (letter == "K")
        {
            GetComponent<RandomMover>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Animator>().enabled = false;
        }
        m_dialogueCanvas.GetComponent<DialogueUI>().m_text.text = "";
        //m_dialogueCanvas.GetComponent<DialogueUI>().m_text.DOKill();
        m_dialogue.UpdateDialogueData(m_dialogueData);
        if (m_dialogueData.m_pieceOfDialogueArray.Count == 0)
        {
            return;
        }
        m_dialogue.UpdateDialogue(m_dialogueData.m_pieceOfDialogueArray[0]);
    }
    IEnumerator ChangeDialoguePosition()
    {
        player = GameObject.FindWithTag("Player");
        while (true)
        {
            m_dialogueCanvas.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
            yield return new WaitForSeconds(0.01f);
        }
        // m_dialogueCanvas.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        // yield return new WaitForSeconds(0.1f);
    }
}