using System.Collections;
using System.Diagnostics.Contracts;
using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 0f;
    [SerializeField] Transform cam;
    bool isMoving = true;
    float speed = 1.5f;
    Vector3 Position;
    float x;
    Rigidbody frog;
    void Awake()
    {
        frog = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(!isMoving)
        {
        Debug.Log(Position);
        cam.position = Position;
        }
    }
    public void ForwardJump(InputAction.CallbackContext context)
    {
        Debug.Log(context.started);
        if(isMoving)
        {
            Debug.Log("move is true");
            if(!context.canceled)
            {
            frog.AddForce( Vector3.up * speed, ForceMode.Impulse);
            frog.AddForce(Vector3.forward * forwardSpeed);
            }
            else if(context.canceled)
            {
            Position = transform.position ;
            }
        }
        isMoving = false;
        Invoke(nameof(Delay),2f);
    }
    private void Delay()
    {
        isMoving = true;
    }
}
