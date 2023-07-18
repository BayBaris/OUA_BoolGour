using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemy : MonoBehaviour
{
    public GameObject enemyShipPrefab; // Düşman gemisi prefabı
    public Transform dusmanBolgesi; // Düşman bölgesi
    public float uretimAraligi = 2f; // Düşman üretim aralığı
    public float uretimYaricap = 5f; // Düşman üretim yarıçapı
    public static MakeEnemy Instance;
    private void Start() {
        Instance = this;
    }

    public void DusmanUret(int adet)
    {
        // Rastgele bir nokta belirle
        int i = 0;
        while (i < adet)
        {
            Vector2 randomNokta = Random.insideUnitCircle * uretimYaricap;
            Vector3 dusmanPozisyon = new Vector3(randomNokta.x, randomNokta.y, 0f);

            // Düşman gemisini oluştur
            GameObject dusmanGemisi = Instantiate(
                enemyShipPrefab,
                dusmanBolgesi.position + dusmanPozisyon,
                Quaternion.identity
            );
            EnemyShipAI dusmanAI = dusmanGemisi.GetComponent<EnemyShipAI>();

            if (dusmanAI != null)
            {
                dusmanAI.hedef = transform; // Oyuncuyu hedef olarak ayarla
            }
            i++;
        }
    }
}
