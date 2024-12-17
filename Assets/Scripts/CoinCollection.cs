using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public void Collect()
    {
        Debug.Log("Coin collected!");

        Invoke(nameof(Collected),1f);
    }

    private void Collected()
    {
        Destroy(this.gameObject);
    }
}
