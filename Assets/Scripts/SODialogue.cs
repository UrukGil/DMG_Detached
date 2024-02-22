using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SODialogue", menuName = "Dialogue/New Dialogue", order = 0)]
public class SODialogue : ScriptableObject
{
    public List<PieceOfDialogue> m_pieceOfDialogueArray = null;
    public Dictionary<string, PieceOfDialogue> m_dialogueIndexDictionary = new Dictionary<string, PieceOfDialogue>();
    // 进行修改时会调用
    public void UpdateDialogueDictionary()
    {
        foreach (var pieceOfDialogue in m_pieceOfDialogueArray)
        {
            if (!m_dialogueIndexDictionary.ContainsKey(pieceOfDialogue.m_index))
            {
                // Debug.Log(pieceOfDialogue.m_index);
                m_dialogueIndexDictionary.Add(pieceOfDialogue.m_index, pieceOfDialogue);
            }
        }
    }
}
[System.Serializable]
public class PieceOfDialogue
{
    public string m_index = null;
    public Sprite m_sprite = null;
    [TextArea]
    public string m_textString = null;
    public List<OptionOfDialogue> m_optionsArray = null;
}
[System.Serializable]
public class OptionOfDialogue
{
    [TextArea]
    public string m_textString = null;
    public string m_targetPieceIndex = null;
    //public bool m_hasQuest = false;
}
