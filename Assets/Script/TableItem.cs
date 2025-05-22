using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableItem : MonoBehaviour
{
    public GameObject[] itemsPosition;
    public GameObject pressPanel;
    public GameObject winPanel; // ?? UI Panel shown on win

    private bool isPress = false;
    private int placedItemCount = 0;

    private void Start()
    {
        pressPanel.SetActive(false);
        winPanel.SetActive(false); // Hide at start
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isPress = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        pressPanel.SetActive(true);

        if (other.CompareTag("Player") && isPress)
        {
            int currentIndex = ItemScript.instance.GetHeldItemIndex();
            if (currentIndex != -1)
            {
                var currentItem = ItemScript.instance.items[currentIndex];

                // Move the item to the correct table position
                currentItem.transform.position = itemsPosition[currentIndex].transform.position;
                currentItem.SetActive(true);

                // Mark item as placed
                placedItemCount++;
                Debug.Log("Items Placed: " + placedItemCount);

                // Check for win condition
                if (placedItemCount >= itemsPosition.Length)
                {
                    winPanel.SetActive(true); // Show the win panel!
                    Debug.Log("?? YOU WIN!");
                }

                // Reset held item
                ItemScript.instance.ResetHeldItem();
            }

            isPress = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressPanel.SetActive(false);
    }
}
