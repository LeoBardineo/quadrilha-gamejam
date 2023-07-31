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
    public static int[] numTasksPorDia = { 4, 4, 4, 4, 3, 1, 1 };
    public static int tasksFeitas = 0;
    public int tasksDoDia;

    void Start()
    {
        tasksDoDia = numTasksPorDia[SceneManager.GetActiveScene().buildIndex - 1];
        tasksFeitas = 0;
    }

    public void comecaDialogo(){
        dialogueTrigger.dialogue = dialogue;
        dialogueManager.actionAfterDialogueEnd = actionAfterDialogueEnd;
        Debug.Log(dialogue.sentences.Length);

        if(!jaInteragiu && isTask && tasksFeitas != tasksDoDia) {
            tasksFeitas++;
            Debug.Log("task feita");
            Debug.LogError("tasksFeitas: " + tasksFeitas);
            Debug.LogError("isPlayerLivre: " + isPlayerLivre);
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

        
        if(isPlayerLivre && SceneManager.GetActiveScene().buildIndex == 5){
            actionAfterDialogueEnd = new UnityEvent();
            actionAfterDialogueEnd.AddListener(() => FindObjectOfType<EventosDoDia>().terminoDeRotinasDia5(isPlayerLivre));
            dialogueManager.actionAfterDialogueEnd = actionAfterDialogueEnd;
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
