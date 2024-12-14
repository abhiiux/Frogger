using System.Collections;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] bool leftOrRight = true ;
    [SerializeField] float speed = 0f;
    Vector3 direction;

    void Start()
    {
        DecideDirection();
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        transform.Translate(direction * speed * Time.deltaTime );
    }

    private void DecideDirection()
    {
        switch (leftOrRight)
        {
            case true :
            direction = Vector3.left;
            break;

            case false :
            direction = Vector3.right;
            break;
        }

    }
    
}
