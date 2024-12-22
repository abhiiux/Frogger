using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] Text CoinText;
    public static int CoinScore = 0;


    public void Collect()
    {
        CoinScore ++;
        UpdateCoinContext();

        Destroy(this.gameObject);
    }


    private void UpdateCoinContext()
    {
        CoinText.text = CoinScore.ToString();
    }

}
