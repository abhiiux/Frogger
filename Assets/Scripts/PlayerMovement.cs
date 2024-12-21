using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f; //How much to move after Jump
    [SerializeField] float delayTime = 0f; // Cooldown time after Jump

    Vector3 moveDirection = Vector3.forward ;
    bool isMoving = true;
    Vector3 Position;
    Rigidbody frog;
    Animator animator;

    void Awake()
    {
        frog = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    public void Move(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector3>();

        if(context.started && isMoving )
        {
            transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            FrogJump(); //Moves forward and plays animation
        }
    }

    private void Delay()
    {
        isMoving = true;
    }

    public void FrogJump() 
    {
        animator.SetTrigger("Jump"); // Jump animation
        frog.AddForce( moveDirection * moveSpeed);

        isMoving = false;
        Invoke(nameof(Delay),delayTime); // Cooldown time after Jump
    }
}
