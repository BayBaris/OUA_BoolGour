using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComtroller : MonoBehaviour
{
    public GameObject minimap;
    public GameObject dialogueBox;
    public GameObject startConvertionButton;
    static bool firstLessonComplated = false;

    private PlayerProfile _playerProfile;

    void OnEnable() {
        _playerProfile = RealmController.Instance.GetPlayerProfile();
        ShipLifeBar.Instance.ShipLifeEffect(_playerProfile.RocketLife);
        FuelBar.Instance.FuelBarEffect(_playerProfile.FuelBar);
    }
    void Start(){
        if (!firstLessonComplated)
        {
            Debug.Log(!firstLessonComplated);
            startConvertionButton.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        ShipLifeBar.Instance.ShipLifeEffect(_playerProfile.RocketLife);
        if (Input.GetKeyDown(KeyCode.M))
        {
            minimap.gameObject.SetActive(!minimap.gameObject.activeSelf);
        }
    }
}
