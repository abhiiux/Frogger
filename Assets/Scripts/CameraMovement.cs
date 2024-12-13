using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distance = 6f;
    [SerializeField] float smoothTime = 0.25f;
    Vector3 velocity = Vector3.zero;
    bool moveCam = false;
    Vector3 offset = new Vector3(0, 5.5f, -3f);
    
    void Update()
    {    
        if(moveCam)
        {
        Vector3 targetPosition = target.position + offset;
        transform.position =  Vector3.SmoothDamp(transform.position,targetPosition, ref velocity, smoothTime);
        moveCam = false;
        }
    }

    public void OnSight()
    {
        float f = target.position.z;
        float c = transform.position.z;
        float x = f - c;
        if(x >= distance)
        {
          moveCam = true;
        }
    }

}
