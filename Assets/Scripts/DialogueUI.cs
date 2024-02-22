using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using DG.Tweening;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public Image m_image = null;
    public TextMeshProUGUI m_text = null;
    public Button m_nextButton = null;
    public GameObject m_dialoguePanel = null;
    public GameObject m_dialogueOptionPanel = null;
    public GameObject m_dialogueOptionPrefab = null;
    public SODialogue m_dialogueData = null;
    public int m_currentDialogueIndex = 0;
    private void LateUpdate()
    {
        // 确保有选项时，“下一个”按钮不出现
        if (m_dialogueOptionPanel.transform.childCount > 0)
        {
            m_nextButton.gameObject.SetActive(false);
        }
    }
    // Listener
    public void NextDialogue()
    {
        // m_text.text = "";
        //m_text.DOKill();
        UpdateDialogue(m_dialogueData.m_pieceOfDialogueArray[m_currentDialogueIndex]);
    }
    public void UpdateDialogueData(SODialogue dialogueData)
    {
        m_dialogueData = dialogueData;
        m_currentDialogueIndex = 0;
    }
    public void UpdateDialogue(PieceOfDialogue pieceOfDialogue)
    {
        m_dialoguePanel.SetActive(true);
        if (pieceOfDialogue.m_sprite != null)
        {
            m_image.enabled = true;
            m_image.sprite = pieceOfDialogue.m_sprite;
        }
        else
        {
            m_image.enabled = false;
        }
        m_text.text = "";
        m_text.text = pieceOfDialogue.m_textString;
        // m_text.DOText(pieceOfDialogue.m_textString, pieceOfDialogue.m_textString.Length * 0.05f);

        if (m_dialogueData.m_pieceOfDialogueArray.Count > m_currentDialogueIndex + 1)
        {
            m_nextButton.gameObject.SetActive(true);
            m_currentDialogueIndex++;
        }
        else
        {
            m_nextButton.gameObject.SetActive(false);
        }
        UpdateDialogueOptions(pieceOfDialogue);
    }
    private void UpdateDialogueOptions(PieceOfDialogue pieceOfDialogue)
    {
        if (m_dialogueOptionPanel.transform.childCount > 0)
        {
            for (int i = 0; i < m_dialogueOptionPanel.transform.childCount; i++)
            {
                Destroy(m_dialogueOptionPanel.transform.GetChild(i).gameObject);
            }
        }
        if (pieceOfDialogue.m_optionsArray.Count > 0)
        {
            m_dialogueOptionPanel.SetActive(true);
            m_dialogueOptionPanel.GetComponent<GraphicRaycaster>().enabled = true;
            for (int j = 0; j < pieceOfDialogue.m_optionsArray.Count; j++)
            {
                var option = Instantiate(m_dialogueOptionPrefab, m_dialogueOptionPanel.transform);
                option.GetComponent<DialogueOptionUI>().UpdateDialogueOption(pieceOfDialogue, pieceOfDialogue.m_optionsArray[j]);
            }
        }
    }
}
