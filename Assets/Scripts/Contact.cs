using UnityEngine;

public class Contact : MonoBehaviour
{

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Coin"))
        {

            GameObject objt = col.gameObject;

            if(objt.TryGetComponent<CoinCollection>(out CoinCollection coin))
            {
                coin.Collect();
            }  

        }
        
    } 

}
