using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;                // vitesse déplacement
    public float rotationSpeedX = 200f;     // sensibilité horizontale
    public float rotationSpeedY = 150f;     // sensibilité verticale
    public Transform cameraTransform;       // la caméra attachée au Player

    private float xRotation = 0f;

    void Update()
    {
        // ===== Déplacement =====
        float vertical = Input.GetAxis("Vertical");   
        float horizontal = Input.GetAxis("Horizontal"); 

        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        transform.position += move * speed * Time.deltaTime;

        // ===== Rotation horizontale =====
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeedX * Time.deltaTime;
        transform.Rotate(Vector3.up, mouseX);

        // ===== Rotation verticale =====
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeedY * Time.deltaTime;
        xRotation -= mouseY;                        // inversé pour que souris haut = regarde en haut
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
