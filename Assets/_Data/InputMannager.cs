using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputMannager : MonoBehaviour
{
    public static InputMannager Instance;
    //[SerializeField] protected Vector3 valueVelocity;
    [SerializeField] protected float horizontal;

    protected virtual void Awake()
    {
        if (InputMannager.Instance != null) Debug.LogError("Only one InputMannager allow", gameObject);
        InputMannager.Instance = this;
    }
    protected virtual void Update()
    {
       
        PlayerInput();
    }

    protected virtual void PlayerInput()
    {
        PlayerController.instance.playerMovement.isJump = Input.GetButtonDown("Jump");
        horizontal= Input.GetAxis("Horizontal");
        PlayerController.instance.playerMovement.moveHorizontal=horizontal;

    }

    internal object GetPosition()
    {
        throw new NotImplementedException();
    }
}
