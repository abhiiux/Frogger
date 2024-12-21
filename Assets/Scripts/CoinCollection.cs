using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] Text CoinText;
    int score = 0;


    public void Collect()
    {
        score ++;
        UpdateCoinContext();

        Destroy(this.gameObject);
    }

    private void Collected()
    {
        Destroy(this.gameObject);
    }

    private void UpdateCoinContext()
    {
        CoinText.text = score.ToString() ;
    }

}
