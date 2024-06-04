using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputMannager : MonoBehaviour
{
    public static InputMannager Instance;
    [SerializeField] protected Vector3 valueVelocity;
   
    [SerializeField] protected bool jump = false;
    protected virtual void Awake()
    {
        if (InputMannager.Instance != null) Debug.LogError("Only one InputMannager allow", gameObject);
        InputMannager.Instance = this;
    }
    protected virtual void Update()
    {
        InPutJumpAndMove();
    }

    protected virtual void InPutJumpAndMove()
    {
        valueVelocity.x = Input.GetAxis("Horizontal");
        valueVelocity.z = Input.GetAxis("Vertical");
         jump = Input.GetButtonDown("Jump");
    }

    public virtual Vector3 GetValueVelocity()
    {
        return valueVelocity;
    }
  
    public virtual bool GetJump()
    {
        return jump;
    }
}
