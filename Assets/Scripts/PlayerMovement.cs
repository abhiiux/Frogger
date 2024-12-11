using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 0f;
    [SerializeField] Transform cam;
    bool isMoving = true;
    bool moveCam = false;
    float speed = 1.5f;
    Vector3 Position;
    Vector3 CamPosition;
    [SerializeField] float distance;
    float x;
    Rigidbody frog;
    void Awake()
    {
        frog = GetComponent<Rigidbody>();
        CamPosition = cam.position;
    }
    void Update()
    {
        if(moveCam)
        {
        Debug.Log("Camera movement initiated");
        float camPosition = Position.z - 3f;
        cam.position = new Vector3(0,5.5f,camPosition);
        moveCam = false;
        }
    }
    public void ForwardJump(InputAction.CallbackContext phase)
    {
        if(isMoving)
        {
            Position = transform.position;
            if(phase.started)
            {
                FrogJump();
                Debug.Log(transform.position);
            }
        }
        isMoving = false;
        Invoke(nameof(Delay),2f);
    }
    private void Delay()
    {
        isMoving = true;
        float f = Position.z;
        float c = CamPosition.z;
        x = f - c;
        Debug.Log(x);
        if(x >= distance)
        {
          moveCam = true;
          Debug.Log("Frog out of sight");
        }

    }
    public void FrogJump()
    {
            frog.AddForce( Vector3.up * speed, ForceMode.Impulse);
            frog.AddForce(Vector3.forward * forwardSpeed);
    }
}
