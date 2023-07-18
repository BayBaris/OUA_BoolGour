using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float hiz = 10f; // Mermi hızı
    private Transform hedef; // Hedefin referansı

    public void AyarlaHedef(Transform hedefTransform)
    {
        hedef = hedefTransform; // Hedefi ayarla
    }

    void Update()
    {
        Vector3 hareket = transform.right * hiz * Time.deltaTime;
        transform.Translate(hareket, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Mermi başka bir şeye çarptığında yapılacak işlemler buraya yazılabilir
        // Örneğin, düşmanı vurmak veya hasar vermek gibi
        if(other.gameObject.tag == "Ship")
        {
            Destroy(gameObject); // Mermiyi yok et
        }
    }
}
