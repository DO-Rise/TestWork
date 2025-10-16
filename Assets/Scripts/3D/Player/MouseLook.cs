using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float _sensitivity = 2f;
    [SerializeField] Transform _playerBody;

    private float _xRotation = 0f;
    private bool _cursorLocked = true;

    private void Start()
    {
        LockCursor(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _cursorLocked = !_cursorLocked;
            LockCursor(_cursorLocked);
        }

        if (_cursorLocked)
        {
            float mouseX = Input.GetAxis("Mouse X") * _sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * _sensitivity;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            _playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    private void LockCursor(bool isLocked)
    {
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isLocked;
    }

}
