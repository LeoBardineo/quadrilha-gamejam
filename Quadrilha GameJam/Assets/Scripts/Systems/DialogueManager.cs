using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public UnityEvent actionAfterDialogueEnd;
    public GameObject dialogueCanvas;
    public static bool isAtDialogue;
    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    
    public void StartDialogue(Dialogue dialogue){
        Debug.Log("Comecando dialogo do " + dialogue.name);
        isAtDialogue = true;
        dialogueCanvas.SetActive(true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        if(sentence.StartsWith("<b>")){
            dialogueText.color = Color.blue;
            sentence = sentence.Replace("<b>", "");
        } else if(sentence.StartsWith("<r>")){
            dialogueText.color = Color.red;
            sentence = sentence.Replace("<r>", "");
        } else {
            dialogueText.color = Color.white;
        }

        dialogueText.text = sentence;

        Debug.Log(sentence);
    }

    public void EndDialogue(){
        Debug.Log("Fim do Dialogo");
        isAtDialogue = false;
        dialogueCanvas.SetActive(false);
        if(actionAfterDialogueEnd != null){
            actionAfterDialogueEnd.Invoke();
        }
    }

    public void EndDialogueSemAcao(){
        Debug.Log("Fim do Dialogo");
        isAtDialogue = false;
        dialogueCanvas.SetActive(false);
    }
}
