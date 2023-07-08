using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float moveSpeed = 5f;

    private void Update()
    {
        if (DialogueManager.isActive)
            return;
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

        // // Uzay gemisini ileri doğru hareket ettiriyoruz
        // transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);


        float horizontalMovement = 0f;
        float verticalMovement = 0f;

        // W tuşuna basılırsa yukarı yönde hareket
        if (Input.GetKey(KeyCode.W))
        {
            verticalMovement = moveSpeed;
        }

        // A tuşuna basılırsa sola yönde hareket
        if (Input.GetKey(KeyCode.A))
        {
            horizontalMovement = -moveSpeed;
        }

        // D tuşuna basılırsa sağa yönde hareket
        if (Input.GetKey(KeyCode.D))
        {
            horizontalMovement = moveSpeed;
        }

        // S tuşuna basılırsa aşağı yönde hareket
        if (Input.GetKey(KeyCode.S))
        {
            verticalMovement = -moveSpeed;
        }

        // Hareket vektörünü oluştur
        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0f);

        // Objeyi hareket ettir
        transform.position += movement * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("PlayerPlanet")){
            SceneManager.LoadScene("PlayerPlanetScene");
        }
    }
}
