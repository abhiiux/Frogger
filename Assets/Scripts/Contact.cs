using UnityEngine;
using UnityEngine.UI;

public class Contact : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    Animator animator;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }


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


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            animator.SetTrigger("Car_collision");
            gameManager.Restart();
        }
            else if(other.CompareTag("Finish"))
            {
                gameManager.Won();
            }
    }

}
