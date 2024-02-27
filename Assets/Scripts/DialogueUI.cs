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
    public Button m_endButton = null;
    public GameObject m_dialoguePanel = null;
    public GameObject m_dialogueOptionPanel = null;
    public GameObject m_dialogueOptionPrefab = null;
    public SODialogue m_dialogueData = null;
    public int m_currentDialogueIndex = 0;
    private bool m_isMemoTrigger = false;
    [SerializeField] float alpha = 0f;
    [SerializeField] GameObject letterUI = null;
    [SerializeField] string letter;
    public DialogueManager m_dialogueManager = null;
    private void Start()
    {
        //m_dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
    }
    private void LateUpdate()
    {
        // 确保有选项时，“下一个”按钮不出现
        if (m_dialogueOptionPanel.transform.childCount > 0)
        {
            m_endButton.gameObject.SetActive(false);
            m_nextButton.gameObject.SetActive(false);
        }
        else
        {
            m_endButton.gameObject.SetActive(true);
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
    public void EndDialogue()
    {
        if (m_dialogueManager != null)
        {
            m_isMemoTrigger = m_dialogueManager.m_isMemoTrigger;
        }
        if (m_isMemoTrigger == true)
        {
            //Memo
            letter = m_dialogueManager.letter;
            GameObject memo = GameObject.FindGameObjectWithTag("Memo");
            memo.transform.GetChild(0).gameObject.SetActive(true);
            List<string> tempList = GameManager.Instance.GetItems();
            for (int i = 0; i < tempList.Count; i++)
            {
                alpha = 0f;
                letterUI = GameObject.FindGameObjectWithTag(tempList[i]);
                if (letterUI != null)
                {
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
            m_dialoguePanel.SetActive(false);
            m_dialogueOptionPanel.SetActive(false);
            m_dialogueOptionPanel.GetComponent<GraphicRaycaster>().enabled = false;
            m_dialogueManager.m_isTalking = false;
            m_dialogueManager.m_hasTalked = true;
        }

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
    IEnumerator ChangeAlpha()
    {
        yield return null;
        if (letterUI != null)
        {
            //Dialogue
            m_dialoguePanel.SetActive(false);
            m_dialogueOptionPanel.SetActive(false);
            m_dialogueOptionPanel.GetComponent<GraphicRaycaster>().enabled = false;
            letterUI.GetComponent<TMP_Text>().font = Resources.Load("FKRASTERGROTESKTRIAL-SHARP SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
            //while (alpha <= 1)
            //{
            //    letterUI.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, Mathf.Min(1, alpha += 0.01f));
            //    //letterUI.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 1);
            //    yield return new WaitForSeconds(0.01f);
            //}
            if (letter == "K")
            {
                m_dialogueManager.GetComponent<RandomMover>().enabled = true;
                m_dialogueManager.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                m_dialogueManager.GetComponent<Animator>().enabled = true;
            }
            m_dialogueManager.m_isTalking = false;
            m_dialogueManager.m_hasTalked = true;
        }
    }
}
