using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float moveSpeed = 5f;

    private void Update()
    {
        // Fare pozisyonunu kameradan alıyoruz
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Z pozisyonunu sıfırlıyoruz (2D için)

        // Uzay gemisi pozisyonunu alıyoruz
        Vector3 shipPosition = transform.position;

        // Fare pozisyonunu hedef olarak belirliyoruz ve yönelim hesaplıyoruz
        Vector3 direction = mousePosition - shipPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Uzay gemisini belirtilen açıya doğru döndürüyoruz
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Uzay gemisini ileri doğru hareket ettiriyoruz
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
