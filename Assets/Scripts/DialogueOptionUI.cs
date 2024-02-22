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

    private void Awake()
    {
        m_dialogueOptionButton = GetComponent<Button>();
        m_dialogueCanvas = GameObject.FindWithTag("Dialogue");
        m_dialogue = m_dialogueCanvas.GetComponent<DialogueUI>();
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
        if (m_targetPieceIndex == "")
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
        else
        {
            m_dialogue.m_currentDialogueIndex = int.Parse(m_targetPieceIndex);
            m_dialogue.UpdateDialogue(m_dialogue.m_dialogueData.m_dialogueIndexDictionary[m_targetPieceIndex]);
        }

    }
}