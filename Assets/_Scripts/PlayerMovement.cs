using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveX;
    [SerializeField] private float moveY;

    [SerializeField] private float speed;

    [SerializeField] private Animator animator;
    
    [Space]

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Joystick joystickMove;
    
    public bool gameFinished;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        GameManager.SharedInstance.onGameFinished.AddListener(GameFinished);
    }

    void Update()
    {
        if (gameFinished == false)
        {
            float space = speed * Time.deltaTime;
        
            moveX = joystickMove.Horizontal * space + Input.GetAxis("Horizontal");
            moveY = joystickMove.Vertical * space + Input.GetAxis("Vertical");

            if (moveX != 0 || moveY != 0)
            {
                var dir = new Vector3(moveX, 0, moveY);

                _rb.AddForce(dir.normalized * space);
                
                animator.SetBool("Moving", true);
            }
            else
            {
                animator.SetBool("Moving", false);
            }
            
        }
        
    }

    void GameFinished()
    {
        animator.SetBool("Moving", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            gameFinished = true;
            if (PointsManager.SharedInstance.alreadyCounting == false)
            {
                GameManager.SharedInstance.onGameFinished.Invoke();
            }
        }
    }   
}
