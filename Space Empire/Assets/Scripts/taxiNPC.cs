using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taxiNPC : MonoBehaviour
{
    public DialogueTrigger trigger;

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("collision geldie");
        if (other.gameObject.CompareTag("Ship"))
        {
            trigger.StartDialogue();
        }
    }
}
