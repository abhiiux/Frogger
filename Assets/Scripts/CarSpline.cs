using UnityEngine;

public class CarSpline : MonoBehaviour
{
  [SerializeField] Transform startPoint ;
  [SerializeField] Transform endPoint ;
  [SerializeField] GameObject vehiclePrefab ;
  [SerializeField] float speed ;
  [SerializeField] bool leftRotation;

  GameObject vehicleInstance; 
  float lerpValue;

    void Start()
    {
      // Instantiating vehicle Prefab with rotation
      CarRotation();

    }

    void Update()
    {

      lerpValue = (lerpValue + Time.deltaTime * speed) % 1f ;

      vehicleInstance.transform.position =  Vector3.Lerp( startPoint.position, endPoint.position, lerpValue);
      
    }

    private void CarRotation()
    {
      if(leftRotation)
      {
        vehicleInstance = Instantiate( vehiclePrefab, startPoint.position, Quaternion.Euler(0, 180, 0));        

      }
        else
        {
          vehicleInstance = Instantiate( vehiclePrefab, startPoint.position, Quaternion.identity);

        }
    }

}
