using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlagTriggerArea : MonoBehaviour
{
    [SerializeField] private BoolGameFlag boolGameFlag;

    private void OnTriggerEnter(Collider other)
    {
        boolGameFlag.Set(true);
    }
}