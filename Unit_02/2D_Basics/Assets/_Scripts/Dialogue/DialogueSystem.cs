using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;
    public GameObject dialogueCanvas;
    public TextMeshProUGUI speaker, content;

    public GameObject choicePanel;
    public TextMeshProUGUI choiceHeader;
    public List<TextMeshProUGUI> choiceList;

    private int dialogueIndex;
    private float lastUpdated;

    public DialogueSegment currentSegment;

    private void Awake()
    {
        instance = this;
    }

    public void SetDialogueSegment(DialogueSegment segment)
    {
        //starts off a new DialogueSegment
        this.currentSegment = segment;
        speaker.text = "";
        content.text = "";
        dialogueIndex = -1;
        lastUpdated = -1f;

        choicePanel.SetActive(false);

        //If the segment has no text, don't load it
        if (segment.lines.Count == 0) return;

        dialogueCanvas.gameObject.SetActive(true);
        NextLine();
    }

    public void NextLine()
    {
        if (Time.time - lastUpdated < 1f) return;
        //if the choice panel is active, we shouldn't proceed to the next line (we're waiting for a choice to be made!)
        if (choicePanel.activeSelf) return;

        dialogueIndex++;
        lastUpdated = Time.time;

        if (dialogueIndex >= currentSegment.lines.Count)
        {
            //if this is the last segment and there are no choices to make, just disable the dialogue system and continue on
            if (currentSegment.options == null || currentSegment.options.Count == 0)
            {
                dialogueCanvas.gameObject.SetActive(false);
                this.currentSegment = null;
            }
            //if this is the last segment and there ARE choices to make, display the choice box
            else
            {
                choiceHeader.text = currentSegment.lines[currentSegment.lines.Count - 1].text;
                //We can support up to 5 options, so we need to make sure we enable/disable buttons to fit however many options are actually provided
                for (int i = 0; i < choiceList.Count; i++)
                {
                    if (i < currentSegment.options.Count)
                    {
                        //Set text on buttons that should be active
                        choiceList[i].text = currentSegment.options[i];
                        choiceList[i].transform.parent.gameObject.SetActive(true);
                    }
                    else
                    {
                        //disable buttons that shouldn't be active
                        choiceList[i].transform.parent.gameObject.SetActive(false);
                    }
                }

                choicePanel.SetActive(true);
            }
            return;
        }

        speaker.text = currentSegment.lines[dialogueIndex].speaker;
        content.text = currentSegment.lines[dialogueIndex].text;
    }

    //this is called by buttons on the choice panel
    public void MakeChoice(int index)
    {
        SetDialogueSegment(currentSegment.consequences[index]);
    }

    public bool DialogueIsActive()
    {
        return dialogueCanvas.activeSelf;
    }

    private void FixedUpdate()
    {
        if (PauseMenu.instance.isPaused) return;
        if (currentSegment == null) return;
        //if the player is pressing any key, proceed to the next line
        if (Input.anyKey) NextLine();
    }
}
