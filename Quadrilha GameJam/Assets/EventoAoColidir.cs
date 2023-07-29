using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventoAoColidir : MonoBehaviour
{
    public UnityEvent interactAction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            interactAction.Invoke();
            Destroy(gameObject);
        }
    }
}
