using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollidableObject : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject interactBox;

    void Start()
    {
        
    }

    void Update()
    {
        if(isInRange && !PauseMenu.isPaused && !DialogueManager.isAtDialogue)
        {
            if(Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !isInRange)
        {
            isInRange = true;
            interactBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isInRange)
        {
            isInRange = false;
            interactBox.SetActive(false);
        }
    }
}
