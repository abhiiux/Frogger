using UnityEngine;
using UnityEngine.UI;

public class Contact : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    Animator animator;
    PlayerMovement playerMovement;


    void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            GameObject objt = other.gameObject;

            if(objt.TryGetComponent<CoinCollection>(out CoinCollection coin))
            {
                coin.Collect();

            }  
        }
        
        else if(other.CompareTag("Car"))
        {
            animator.SetTrigger("Car_collision");
            playerMovement.moveSpeed = 0;

            gameManager.Restart();
        }
            else if(other.CompareTag("Finish"))
            {
                gameManager.Won();
            }
    }

}
