using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private bool isPickup = false;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if(isPickup && Input.GetKeyDown(KeyCode.E))
        {
            PickUpObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            isPickup = true;
        }
    }

    void PickUpObject()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                Instantiate(itemButton, inventory.slots[i].transform, false);
                Destroy(gameObject);
                break;
            }
        }
    }
}
