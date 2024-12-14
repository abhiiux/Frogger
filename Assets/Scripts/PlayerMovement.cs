using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f; //How much to move after Jump
    [SerializeField] CameraMovement camScript;
    [SerializeField] float delayTime = 0f; // Cooldown time after Jump
    [SerializeField] float jumpHeight = 1.5f; // How high to Jump

    Vector3 moveDirection;
    bool isMoving = true;
    Vector3 Position;
    Rigidbody frog;

    void Awake()
    {
        frog = GetComponent<Rigidbody>();
    }

    public void ForwardJump(InputAction.CallbackContext phase)
    {
        if(isMoving)
        {
            if(phase.started)
            {
                moveDirection = Vector3.forward;
                FrogJump();
            }
        }
        // Position = transform.position;
        isMoving = false;
        Invoke(nameof(Delay),delayTime);
    }

    public void Turn()
    {
        //turn when pressed!
    }

    private void Delay()
    {
        isMoving = true;
        camScript.OnSight(); // Calculating distance b/w player and camera
    }

    public void FrogJump()
    {
            frog.AddForce( Vector3.up * jumpHeight, ForceMode.Impulse);
            frog.AddForce( moveDirection * moveSpeed);
    }
}
