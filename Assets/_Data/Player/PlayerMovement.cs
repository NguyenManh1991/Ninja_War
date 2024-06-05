using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     
    [Header("Movement")]
    public Vector3 movement = Vector3.zero;
    public bool isTurnright = true;   
    public bool isMoving = false;
    public float speed = 2f;
    public float moveHorizontal;
    [Header("Jump")]
    public float jumpHeight = 7f;
    public float fall = 3f;
    public bool isJump = false;
    public bool groundedPlayer = false;
    protected virtual void FixedUpdate()
    {
        groundedPlayer = IsGrounded();
        PlayerJump(); 
        Playerfall();
        Moving();
        MoveAnimation();     
        Turning();
        PlayerController.instance.characterController.Move(movement*Time.fixedDeltaTime);
    }

  
    protected virtual void MoveAnimation()
    {
        if (isMoving)
        {
            MoveOnIdle();
        }
        else MoveOfIdle();
    }

    protected virtual void MoveOnIdle()
    {

        PlayerController.instance.animator.SetInteger("Stage", 1);
    }

    protected virtual void MoveOfIdle()
    {
        PlayerController.instance.animator.SetInteger("Stage", 0);
    }

    protected virtual void Moving()
    {
        if (!IsMoving()) return;
      
        movement.x = speed*moveHorizontal;
    }

    protected virtual void PlayerJump()
    {
        if (!groundedPlayer) return;
         
        if (isJump) movement.y = jumpHeight;
    }
    protected virtual void Playerfall()
    {
        movement.y -= fall*Time.fixedDeltaTime;
       // if (playerVelocity.y <= -1) playerVelocity.y = -1;
    }
    public virtual bool IsMoving()
    {

        isMoving = false;
        if(isJump) isMoving = true;
        if (moveHorizontal != 0) isMoving = true;
        return isMoving;
    }
    protected virtual bool IsGrounded()
    {
        return PlayerController.instance.characterController.isGrounded;
    }

    //protected virtual void Turning()
    //{
    //    isTurnright = true;
    //    if (InputMannager.Instance.GetPosition().x != 0) direction = InputMannager.Instance.GetPosition().x;
    //    if (InputMannager.Instance.GetPosition().x < 0) isTurnright = false;
    //    Vector3 playerRotation = transform.parent.localScale;
    //    if (direction > 0) playerRotation.x = 1f;
    //    else playerRotation.x = -1f;
    //    transform.parent.localScale = playerRotation;
    //}
    protected virtual void Turning()
    {
        Quaternion playerRotation = transform.parent.rotation;
        if (moveHorizontal < 0)
        {
            playerRotation.y = 180;
        }
        if (moveHorizontal > 0)
        {
            playerRotation.y = 0;
        }
        transform.parent.rotation = playerRotation;
    }
}
