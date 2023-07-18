using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipAI : MonoBehaviour
{
    public Transform hedef;                // Takip edilecek hedefin referansı
    public float takipHizi = 2f;           // NPC'nin takip hızı
    public float ateslemeMesafesi = 10f;    // Ateşleme mesafesi
    public GameObject mermiPrefab;         // Mermi prefabı
    public Transform atesNoktasi;          // Ateşin çıkacağı nokta

    private float sonrakiAtesZamani = 0f;   // Bir sonraki ateş zamanı
    public float atesArasiSure = 1f;        // Ateş arası süre

    void Update()
    {
        if (hedef == null)
        {
            return;
        }

        // Hedefe doğru dönme
        Vector3 yon = hedef.position - transform.position;
        float aci = Mathf.Atan2(yon.y, yon.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(aci, Vector3.forward);

        // Hedefe doğru hareket etme
        transform.position = Vector2.MoveTowards(transform.position, hedef.position, takipHizi * Time.deltaTime);

        // Hedefe ateş etme
        if (Vector2.Distance(transform.position, hedef.position) <= ateslemeMesafesi && Time.time >= sonrakiAtesZamani)
        {
            AtesEt();
            sonrakiAtesZamani = Time.time + atesArasiSure;
        }
    }

    void AtesEt()
    {
        // Mermi oluşturma
        GameObject mermi = Instantiate(mermiPrefab, atesNoktasi.position, atesNoktasi.rotation);
        // Mermi hareketini ayarlama
        EnemyBullet mermiScript = mermi.GetComponent<EnemyBullet>();
        if (mermiScript != null)
        {
            mermiScript.AyarlaHedef(hedef);
        }
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
