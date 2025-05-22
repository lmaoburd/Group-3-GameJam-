using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene loading or ending the game

public class ItemScript : MonoBehaviour
{
    public GameObject[] items;
    public GameObject[] itemCheckBox;

    private bool[] collected;

    void Start()
    {
        collected = new bool[items.Length];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ItemFood"))
        {
            CollectItem(0);
        }

        if (other.CompareTag("ItemBootle"))
        {
            CollectItem(1);
        }
    }

    void CollectItem(int index)
    {
        if (!collected[index])
        {
            collected[index] = true;
            items[index].SetActive(false);
            itemCheckBox[index].SetActive(true);

            CheckAllItemsCollected();
        }
    }

    void CheckAllItemsCollected()
    {
        foreach (bool isCollected in collected)
        {
            if (!isCollected)
                return;
        }

        // All items are collected!
        Debug.Log("All mission items collected! Game Finished!");

        // Example action: load finish scene or show UI
        // SceneManager.LoadScene("WinScene");
        // OR show a finish message
        // finishUI.SetActive(true);
    }
}
