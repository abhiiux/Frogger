using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 0f;
    [SerializeField] Transform cam;
    [SerializeField] CameraMovement camScript;
    bool isMoving = true;
    float speed = 1.5f;
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
        Invoke(nameof(Delay),2f);
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
