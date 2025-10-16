using UnityEngine;

public class Finish3D : MonoBehaviour
{
    [SerializeField] private GameUI _gameUI;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            _gameUI.WinWindow();
        }   
    }
}
