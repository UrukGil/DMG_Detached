using System.Collections;
using System.Collections.Generic;
using TMPro;
//using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOptionUI : MonoBehaviour
{
    public TextMeshProUGUI m_dialogueOptionText = null;
    public Button m_dialogueOptionButton = null;
    public PieceOfDialogue m_pieceOfDialogue = null;
    //private bool m_hasQuest = false;
    private string m_targetPieceIndex = null;
    private GameObject m_dialogueCanvas = null;
    private DialogueUI m_dialogue = null;
    private bool m_isMemoTrigger = false;
    [SerializeField] float alpha = 0f;
    [SerializeField] GameObject letterUI = null;
    [SerializeField] string letter;
    public DialogueManager m_dialogueManager = null;

    private void Awake()
    {
        m_dialogueOptionButton = GetComponent<Button>();
        m_dialogueCanvas = GameObject.FindWithTag("Dialogue");
        m_dialogue = m_dialogueCanvas.GetComponent<DialogueUI>();
        //m_dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
    }
    public void UpdateDialogueOption(PieceOfDialogue pieceOfDialogue, OptionOfDialogue optionOfDialogue)
    {
        m_pieceOfDialogue = pieceOfDialogue;
        m_dialogueOptionText.text = optionOfDialogue.m_textString;
        m_targetPieceIndex = optionOfDialogue.m_targetPieceIndex;
        //m_hasQuest = optionOfDialogue.m_hasQuest;
    }

    // Listener
    public void OnDialogueOptionUIClicked()
    {
        m_dialogueCanvas.GetComponent<DialogueUI>().m_text.text = "";
        //m_dialogueCanvas.GetComponent<DialogueUI>().m_text.DOKill();
        if (m_targetPieceIndex == "" && m_isMemoTrigger == false)
        {
            m_dialogue.m_dialoguePanel.SetActive(false);
            m_dialogue.m_dialogueOptionPanel.SetActive(false);
            m_dialogue.m_dialogueOptionPanel.GetComponent<GraphicRaycaster>().enabled = false;
            foreach (var dialogueManager in GameObject.FindObjectsOfType<DialogueManager>())
            {
                dialogueManager.m_isTalking = false;
                dialogueManager.m_hasTalked = true;
            }
        }
        else if (m_targetPieceIndex == "" && m_isMemoTrigger == true)
        {
            //Memo
            m_dialogueManager = m_dialogue.m_dialogueManager;
            if (m_dialogueManager != null)
            {
                m_isMemoTrigger = m_dialogueManager.m_isMemoTrigger;
            }
            letter = m_dialogueManager.letter;
            GameObject memo = GameObject.FindGameObjectWithTag("Memo");
            memo.transform.GetChild(0).gameObject.SetActive(true);
            List<string> tempList = GameManager.Instance.GetItems();
            for (int i = 0; i < tempList.Count; i++){
                alpha = 0f;
                letterUI = GameObject.FindGameObjectWithTag(tempList[i]);
                if (letterUI != null){
                    letterUI.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 255);
                }
            }
            letterUI = GameObject.FindGameObjectWithTag(letter);
            GameManager.Instance.AddItem(letter);
            alpha = 0f;
            StartCoroutine(ChangeAlpha());
        }
        else
        {
            m_dialogue.m_currentDialogueIndex = int.Parse(m_targetPieceIndex);
            m_dialogue.UpdateDialogue(m_dialogue.m_dialogueData.m_dialogueIndexDictionary[m_targetPieceIndex]);
        }

    }
    IEnumerator ChangeAlpha()
    {
        if (letterUI != null)
        {
            while (alpha <= 1)
            {
                print(alpha);
                letterUI.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, Mathf.Min(1, alpha += 0.01f));
                yield return new WaitForSeconds(0.01f);
            }
            if (letter == "K")
            {
                m_dialogueManager.GetComponent<RandomMover>().enabled = true;
                //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                m_dialogueManager.GetComponent<Animator>().enabled = true;
            }
            //Dialogue
            m_dialogue.m_dialoguePanel.SetActive(false);
            m_dialogue.m_dialogueOptionPanel.SetActive(false);
            m_dialogue.m_dialogueOptionPanel.GetComponent<GraphicRaycaster>().enabled = false;
            m_dialogueManager.m_isTalking = false;
            m_dialogueManager.m_hasTalked = true;
        }
    }
}