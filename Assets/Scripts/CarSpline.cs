using UnityEngine;

public class CarSpline : MonoBehaviour
{
    [SerializeField] Transform from ;
    [SerializeField] Transform to ;
    [SerializeField] Transform vehicle ;
    [SerializeField] float speed ;
    
    float Value;

  void Update()
  {
    Value = (Value + Time.deltaTime * speed) % 1f;

    vehicle.position = Vector3.Lerp(from.position,to.position, Value);
  }

}
