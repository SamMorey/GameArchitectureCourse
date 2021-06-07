using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogGiver : MonoBehaviour
{
    [SerializeField] TextAsset _dialog;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<ThirdPersonMover>();
        if (player != null)
        {
            transform.LookAt(player.transform);
        }
            
        if (other.GetComponent<ThirdPersonMover>() != null)
        {
            FindObjectOfType<DialogController>().StartDialog(_dialog);
        }
    }
}
