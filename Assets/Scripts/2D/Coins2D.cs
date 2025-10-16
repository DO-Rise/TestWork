using UnityEngine;

public class Coins2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GameUI.Instance.AddCoin();
        }
    }
}
