using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableItem : MonoBehaviour
{
    public GameObject[] itemsPosition;

    private bool isPress = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isPress = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isPress)
        {
            int currentIndex = ItemScript.instance.GetHeldItemIndex();
            if (currentIndex != -1)
            {
                var currentItem = ItemScript.instance.items[currentIndex];

                // Move the item to the table's position
                currentItem.transform.position = itemsPosition[currentIndex].transform.position;
                currentItem.SetActive(true);

                // Reset held item
                ItemScript.instance.ResetHeldItem();
            }

            isPress = false;
        }
    }
}
