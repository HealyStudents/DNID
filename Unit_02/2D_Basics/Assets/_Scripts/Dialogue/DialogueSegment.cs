using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueSegment : ScriptableObject
{
    public List<DialogueLine> lines;

    //if these aren't null, that means this segment ends in a choice and will lead to another segment
    public List<string> options;
    //Consequences line up (by index) with options ^^
    //When a player chooses a given option, it should continue the dialogue to the linked corresponding segment (like a linked list structure)
    public List<DialogueSegment> consequences;
}
