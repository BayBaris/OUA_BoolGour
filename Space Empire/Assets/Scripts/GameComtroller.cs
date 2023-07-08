using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComtroller : MonoBehaviour
{
    public GameObject minimap;
    public GameObject dialogueBox;
    public GameObject startConvertionButton;
    bool firstLessonComplated = false;
    void start(){
        if (!firstLessonComplated)
        {
            dialogueBox.gameObject.SetActive(true);
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
