using UnityEngine;
using UnityEngine.UI;

public class Contact : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioManager audioManager;
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
            audioManager.PlayAudio(audioManager.carCrashClip);
            playerMovement.didFrogCollide = true;
            
            gameManager.Restart();
        }
            else if(other.CompareTag("Finish"))
            {
                gameManager.Won();
                audioManager.PlayAudio(audioManager.gameOverClip);
            }
    }

}
