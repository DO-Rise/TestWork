using UnityEngine;

public class Coins3D : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GameUI.Instance.AddCoin();
        }
    }
}
