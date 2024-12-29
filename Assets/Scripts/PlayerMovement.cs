using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f; //How much to move after Jump
    [SerializeField] float delayTime = 0f; // Cooldown time after Jump
    [SerializeField] AudioManager audioManager; // Reference to AudioManager script

    bool isMoving = true;
    internal bool didFrogCollide = false;
    Vector3 moveDirection = Vector3.forward ;
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
            FrogJump(); //Moves forward and plays animation
        }
    }

    private void Delay()
    {
        isMoving = true;
    }

    public void FrogJump() 
    {
        if( didFrogCollide ) return; // If frog collided with car, then return

        transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up); // Rotate frog in the direction of movement
        animator.SetTrigger("Jump"); // Jump animation
        frog.AddForce( moveDirection * moveSpeed);
        audioManager.PlayAudio(audioManager.jumpClip); // Jump sound

        isMoving = false;
        Invoke(nameof(Delay),delayTime); // Cooldown time after Jump
    }
}
