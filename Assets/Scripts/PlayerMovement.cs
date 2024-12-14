using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f; //How much to move after Jump
    [SerializeField] CameraMovement camScript;
    [SerializeField] float delayTime = 0f; // Cooldown time after Jump
    [SerializeField] float jumpHeight = 1.5f; // How high to Jump

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
        if(context.started && isMoving)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            FrogJump();
        }
        isMoving = false;
        Invoke(nameof(Delay),delayTime); // Cooldown time after Jump
    }

    private void Delay()
    {
        isMoving = true;
        camScript.OnSight(); // Calculating distance b/w player and camera
    }

    public void FrogJump()
    {
        animator.SetTrigger("Jump");
        frog.AddForce( Vector3.up * jumpHeight, ForceMode.Impulse);
        frog.AddForce( moveDirection * moveSpeed);
    }
}
