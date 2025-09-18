using UnityEngine;
using UnityEngine.InputSystem;

public class BaseController : MonoBehaviour
{
    public float rotationSpeed = 0.3f;

    void Update()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float horizontalRotation = mouseDelta.x * rotationSpeed;

        transform.localEulerAngles += new Vector3(0f, horizontalRotation, 0f);
    }
}
