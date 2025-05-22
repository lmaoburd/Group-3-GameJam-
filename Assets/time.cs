using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
  
    public float timer;
   
    public void Start()
    {

        one = GameObject.FindGameObjectWithTag("One");
        two = GameObject.FindGameObjectWithTag("Two");
    }
    public void Update()
    {
       
            timer += Time.deltaTime;

        if (timer >= 5)
        {
            one.SetActive(false);
            two.SetActive(true);
        
        }

        if(timer >= 10)
        {
            one.SetActive(false);
            two.SetActive(false);
           
           
        }
    }
}
