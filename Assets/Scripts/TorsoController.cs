using UnityEngine;
using UnityEngine.InputSystem;

public class TorsoController : MonoBehaviour
{
    public float rotationSpeed = 0.3f;

    private float verticalRotation = 0f; 

    void Update()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        verticalRotation -= mouseDelta.y * rotationSpeed;

        transform.localEulerAngles = new Vector3(verticalRotation, 0f, 0f);
    }
}


