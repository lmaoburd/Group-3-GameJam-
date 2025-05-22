using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public static ItemScript instance;
    public GameObject[] items;         // The world item objects (should be tagged)
    public Image[] itemCheckBox;       // UI indicators for each item
    public GameObject pressPanel;

    private int currentItemIndex = -1; // -1 = no item held
    private bool isPress = false;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        pressPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPress = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            pressPanel.SetActive(true);
        }
        if (isPress)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (other.gameObject == items[i])
                {
                    SwapItem(i);
                    isPress = false;
                    break;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            pressPanel.SetActive(false);
        }
    }

    void SwapItem(int newIndex)
    {
        // Drop current item
        if (currentItemIndex != -1 && currentItemIndex != newIndex)
        {
            items[currentItemIndex].SetActive(true);
            items[currentItemIndex].transform.position = transform.position;
            itemCheckBox[currentItemIndex].color = Color.white;
        }

        // Pick up new item
        items[newIndex].SetActive(false);
        pressPanel.SetActive(false);
        itemCheckBox[newIndex].color = Color.green;
        currentItemIndex = newIndex;
    }

    public int GetHeldItemIndex()
    {
        return currentItemIndex;
    }

    public void ResetHeldItem()
    {
        currentItemIndex = -1;
    }

}
