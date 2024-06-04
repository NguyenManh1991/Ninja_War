using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;    
    public Transform playerModel;
    public Animator animator;
    public CharacterController characterController;

    protected virtual void Awake()
    {
        if (PlayerController.instance != null) Debug.LogError("Only one PlayerController allow", gameObject);
        PlayerController.instance = this;
        LoadComponents();
       
    }

    protected virtual void LoadComponents()
    {
        LoadChar();
    }
    
    protected virtual void Reset()
    {
        LoadComponents();
    }
    protected virtual void LoadChar()
    {
        characterController = GetComponent<CharacterController>();
        if (playerModel != null) return;
        playerModel = transform.Find("Model").GetComponent<Transform>();
        animator = transform.Find("Model").GetComponent<Animator>();
        
    }
}
