using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] Text CoinText;
    [SerializeField] AudioManager audioManager;
    public static int CoinScore = 0;

    void Start()
    {
        CoinScore = 0;
        UpdateCoinContext();
    }


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
