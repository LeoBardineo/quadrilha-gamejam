using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.JSONSerializeModule;



public class DialogueTriggerv2 : MonoBehaviour
{
    Dialogue dialogue;
    public string jsonString;


    //dialogue = JsonUtility.FromJson<Dialogue>(jsonString);


    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(JsonUtility.FromJson<Dialogue>(jsonString));
    }
}
