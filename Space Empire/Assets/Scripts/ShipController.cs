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


        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shipPosition = transform.position;
        Vector3 direction = mousePosition - shipPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        Vector3 movement;

        // W tuşuna basılırsa yukarı yönde hareket
        if (Input.GetKey(KeyCode.W))
        {
            movement = transform.right * moveSpeed * Time.deltaTime;
            transform.Translate(movement, Space.World); 
        }

        if (Input.GetKey(KeyCode.A))
        {
           // horizontalMovement = -moveSpeed;
           Vector3 hareket = transform.right * moveSpeed * Time.deltaTime;
            transform.Translate(hareket, Space.Self); 
        }

        // D tuşuna basılırsa sağa yönde hareket
        if (Input.GetKey(KeyCode.D))
        {
           // horizontalMovement = moveSpeed;
           Vector3 hareket = -transform.right * moveSpeed * Time.deltaTime;
            transform.Translate(hareket, Space.Self);
        }

        // S tuşuna basılırsa aşağı yönde hareket
        if (Input.GetKey(KeyCode.S))
        {
            movement = -transform.right * moveSpeed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }

        // Hareket vektörünü oluştur
        // Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0f);

        // // Objeyi hareket ettir
        // transform.position += movement * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("PlayerPlanet")){
            SceneManager.LoadScene("PlayerPlanetScene");
        }else if (other.gameObject.CompareTag("MultiPlayerPlanet"))
        {
            SceneManager.LoadScene("MultiPlayerPlanetScene");
        }

        if(other.tag == "EnemyBullet") {
            RealmController.Instance.RocketLife(-1);
        }else if (other.tag == "EnemyShip" )
        {
            RealmController.Instance.RocketLife(-5);
        }
    }
}
