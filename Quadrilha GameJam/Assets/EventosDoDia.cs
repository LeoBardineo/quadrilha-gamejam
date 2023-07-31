using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EventosDoDia : MonoBehaviour
{
    public PlayableDirector timeline;
    public AudioListener audioListener;
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    public UnityEvent actionAfterDialogueEnd = null;
    public Dialogue dialogoRotinaEnd;
    
    public void terminarDia(){
        esperaSegundos(System.Convert.ToInt32(timeline.duration));
    }

    public void terminoDeRotinasDia5(bool isPlayerLivre){
        if(!isPlayerLivre) return;
        dialogueTrigger.dialogue = dialogoRotinaEnd;
        dialogueManager.actionAfterDialogueEnd = actionAfterDialogueEnd;
        dialogueTrigger.TriggerDialogue();
    }

    public void cutsceneFinalFicar(){
        SceneManager.LoadScene("Cutscene_Ficar");
    }

    public void cutsceneFinalSair(){
        SceneManager.LoadScene("Cutscene_Sair");
    }

    void esperaSegundos(int segundos){
        StartCoroutine(esperaCoroutine(segundos));
    }

    IEnumerator esperaCoroutine(int segundos){
        timeline.Play();
        audioListener.enabled = false;
        yield return new WaitForSeconds(segundos);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
