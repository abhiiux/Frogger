using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] Text CoinText;
    [SerializeField] AudioManager audioManager;
    public static int CoinScore = 0;


    public void Collect()
    {
        CoinScore ++;
        UpdateCoinContext();
        audioManager.PlayAudio(audioManager.coinCollectionClip);

        Destroy(this.gameObject);
    }


    private void UpdateCoinContext()
    {
        CoinText.text = CoinScore.ToString();
    }

}
