using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothTime = 0.25f;
    [SerializeField] Vector3 offset = new Vector3(0, 10f, -3f);
    
    void FixedUpdate()
    {    

            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.Lerp(transform.position,targetPosition, smoothTime);
            // transform.position = targetPosition;
        
    }
}
