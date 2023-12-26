using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Dialogue", fileName = "Dialogue")]
public class DialogueScriptableObject : ScriptableObject
{
    [TextArea]
    public string[] dialogue;

}
