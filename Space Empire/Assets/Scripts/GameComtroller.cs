using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComtroller : MonoBehaviour
{
    public GameObject minimap;
    public GameObject dialogueBox;
    public GameObject startConvertionButton;
    static readonly bool firstLessonComplated = false;
    void Start(){
        Debug.Log("deneme 1 2 3");
        if (!firstLessonComplated)
        {
            Debug.Log(!firstLessonComplated);
            startConvertionButton.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            minimap.gameObject.SetActive(!minimap.gameObject.activeSelf);
        }
    }
}
