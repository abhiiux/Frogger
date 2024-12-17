using UnityEngine;

public class CarSpline : MonoBehaviour
{
    [SerializeField] Transform PointA;
    [SerializeField] Transform PointB;
    [SerializeField] Transform PointAB;
    [SerializeField] float speed;
    
    float Value;

  void Update()
  {
    Value = (Value + Time.deltaTime * speed) % 1f;

    PointAB.position = Vector3.Lerp(PointA.position,PointB.position, Value);
  }

}
