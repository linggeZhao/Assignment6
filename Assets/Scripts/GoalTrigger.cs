using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalTrigger : MonoBehaviour
{
    public GameObject winText; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You win!!!");
            winText.SetActive(true);
        }
    }
}
