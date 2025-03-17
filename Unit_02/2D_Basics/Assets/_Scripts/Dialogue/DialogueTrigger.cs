using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueSegment segment;
    public Camera dialogueCam;

    private void FixedUpdate()
    {
        dialogueCam.gameObject.SetActive(DialogueSystem.instance.DialogueIsActive());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (DialogueSystem.instance.DialogueIsActive()) return;
            DialogueSystem.instance.SetDialogueSegment(segment);
        }
    }
}
