using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] panels;
    private bool isInventoryActive = false;
    private bool isMenuActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInventoryActive = !isInventoryActive;
            panels[0].SetActive(isInventoryActive);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActive = !isMenuActive;
            panels[1].SetActive(isMenuActive);
        }
    }
}
