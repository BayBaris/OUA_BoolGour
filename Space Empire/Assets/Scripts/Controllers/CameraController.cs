using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Uzay gemisi nesnesinin transform bileşeni

    public float smoothSpeed = 0.125f; // Kamera hareketinin yumuşaklığı
    public float distance = 5f; // Kamera ile uzay gemisi arasındaki mesafe

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        // Uzay gemisinin pozisyonunu alıyoruz
        Vector3 targetPosition = target.position;

        // Kameranın hedef pozisyonunu hesaplıyoruz
        Vector3 desiredPosition = targetPosition - (transform.forward * distance);

        // Kamerayı yumuşak bir şekilde hedef pozisyona taşıyoruz
        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref velocity,
            smoothSpeed
        );
    }
}
