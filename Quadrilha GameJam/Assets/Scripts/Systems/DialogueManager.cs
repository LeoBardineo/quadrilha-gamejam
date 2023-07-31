using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public UnityEvent actionAfterDialogueEnd;
    public GameObject dialogueCanvas;
    public static bool isAtDialogue;
    public Queue<string> sentences;
    public Color32 corAzul, corVermelha, corRoxa;
    public DialogoAoColidir dialogoAoColidir;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        if(SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 7){
            dialogoAoColidir.comecaDialogo();
        }
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
            dialogueText.color = corAzul;
            sentence = sentence.Replace("<b>", "");
        } else if(sentence.StartsWith("<r>")){
            dialogueText.color = corVermelha;
            sentence = sentence.Replace("<r>", "");
        } else if(sentence.StartsWith("<roxo>")){
            dialogueText.color = corRoxa;
            sentence = sentence.Replace("<roxo>", "");
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
