using UnityEngine;

public class CarSpline : MonoBehaviour
{
  [SerializeField] Transform startPoint ;
  [SerializeField] Transform endPoint ;
  [SerializeField] GameObject vehiclePrefab ;
  [SerializeField] float speed ;

   GameObject vehicleInstance; 
  float lerpValue;

    void Start()
    {
      // Instantiating vehicle Prefab
      vehicleInstance = Instantiate( vehiclePrefab, startPoint.position, Quaternion.identity);
    }

    void Update()
    {

      lerpValue = (lerpValue + Time.deltaTime * speed) % 1f ;

      vehicleInstance.transform.position =  Vector3.Lerp( startPoint.position, endPoint.position, lerpValue);
      
    }

}
