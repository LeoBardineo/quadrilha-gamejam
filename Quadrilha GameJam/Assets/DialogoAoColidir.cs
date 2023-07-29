using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DialogoAoColidir : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    public Dialogue dialogue;
    public Dialogue dialogueJaInteragiu;
    public Dialogue dialoguePlayerLivre;
    public UnityEvent actionAfterDialogueEnd = null;
    public UnityEvent actionAfterDialogueEndJaInteragiu = null;
    public bool isDialogoAoInteragir = false;
    public bool destruirAoInteragir = false;
    public bool jaInteragiu = false;
    public bool isCama = false;
    public bool isTask = false;
    public bool isPlayerLivre = false;
    public static int[] numTasksPorDia = { 4, 4, 4, 4, 4 };
    public static int tasksFeitas = 0;
    public int tasksDoDia;

    void Start()
    {
        tasksDoDia = numTasksPorDia[SceneManager.GetActiveScene().buildIndex - 1];
    }

    public void comecaDialogo(){
        dialogueTrigger.dialogue = dialogue;
        dialogueManager.actionAfterDialogueEnd = actionAfterDialogueEnd;

        if(!jaInteragiu && isTask && tasksFeitas != tasksDoDia) {
            tasksFeitas++;
            Debug.Log("task feita");
        }

        if(tasksFeitas == tasksDoDia){
            isPlayerLivre = true;
        }

        if(isPlayerLivre && isCama){
            dialogueTrigger.dialogue = dialogue;
            dialogueManager.actionAfterDialogueEnd = actionAfterDialogueEndJaInteragiu;
        } else if(!isPlayerLivre && isCama || isPlayerLivre) {
            dialogueTrigger.dialogue = dialoguePlayerLivre;
        } else if(jaInteragiu && dialogueJaInteragiu.sentences.Length > 0){
            dialogueTrigger.dialogue = dialogueJaInteragiu;
            dialogueManager.actionAfterDialogueEnd = actionAfterDialogueEndJaInteragiu;
        }

        dialogueTrigger.TriggerDialogue();
        
        if(destruirAoInteragir){
            Destroy(gameObject);
        }

        jaInteragiu = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !isDialogoAoInteragir)
        {
            comecaDialogo();
        }
    }
}
