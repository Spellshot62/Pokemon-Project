using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    //public LayerMask interactableLayer;
    public LayerMask grassLayer;

    public event Action OnEncountered;

    private bool isMoving;
    private Vector2 input;

    private Animator animator; 

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        //Checks movement input from player
        if(!isMoving){
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //removes diagonal movement
            if(input.x != 0) input.y = 0;

            //Calculates new player position
            if(input != Vector2.zero){
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }
        //Reads isMoving for walking vs idle animations
        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos){
        isMoving = true;

        //Uses player input to change player position
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
        CheckForEncounters();
    }

    private bool IsWalkable(Vector3 targetPos){
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null){
            return false;
        }

        return true;
    }

    private void CheckForEncounters(){
        if(Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null){
            if(UnityEngine.Random.Range(1,101) <= 10){
                OnEncountered();
            }
        }
    }
}
