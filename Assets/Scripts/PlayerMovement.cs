using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 0f; //How much forward do you want to Jump
    [SerializeField] CameraMovement camScript;
    [SerializeField] float delayTime = 0f; // Cooldown time after Jump
    bool isMoving = true;
    float speed = 1.5f; // How high to Jump
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
                FrogJump();
            }
        }
        Position = transform.position;
        isMoving = false;
        Invoke(nameof(Delay),delayTime);
    }

    private void Delay()
    {
        isMoving = true;
        camScript.OnSight(); // Calculating distance b/w player and camera
    }
    
    public void FrogJump()
    {
            frog.AddForce( Vector3.up * speed, ForceMode.Impulse);
            frog.AddForce(Vector3.forward * forwardSpeed);
    }
}
