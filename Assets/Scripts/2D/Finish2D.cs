using UnityEngine;

public class Finish2D : MonoBehaviour
{
    [SerializeField] private GameUI _gameUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _gameUI.WinWindow();
        }   
    }
}
