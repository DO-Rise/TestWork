using UnityEngine;

public class Abyss : MonoBehaviour
{
    [SerializeField] private Transform _resetPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();

            controller.enabled = false;
            other.transform.position = _resetPoint.position;
            controller.enabled = true;
        }
    }
}
