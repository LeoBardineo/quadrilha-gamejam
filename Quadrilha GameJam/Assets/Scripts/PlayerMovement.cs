using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D playerRB;
    SpriteRenderer spriteRenderer;
    Animator animator;
    Vector2 movement, lastMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        DialogoAoColidir.tasksFeitas = 0;
        DialogoAoColidir.isPlayerLivre = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused || DialogueManager.isAtDialogue) return;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if(movement.sqrMagnitude != 0)
        {
            lastMovement = movement;
            animator.SetFloat("LastHorizontal", lastMovement.x);
            animator.SetFloat("LastVertical", lastMovement.y);
        }
        spriteRenderer.flipX = movement.x < 0.0f || lastMovement.x < 0.0f;
    }

    private void FixedUpdate()
    {
        if (PauseMenu.isPaused || DialogueManager.isAtDialogue) return;
        playerRB.MovePosition(playerRB.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
