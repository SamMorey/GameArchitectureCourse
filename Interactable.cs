using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Material _nonInteractable;
    [SerializeField] Material _Interactable;
    [SerializeField] float _maxDistance = 10f;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] List<GameEvent> _gameEventToInvoke = new List<GameEvent>();
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _maxDistance, _layerMask))
        {
            if (Input.GetKey(KeyCode.F))
            {
                MeshRenderer meshRenderer = hit.transform.GetComponent<MeshRenderer>();
                meshRenderer.materials = new Material[] {_Interactable};
                GameEvent.RaiseEvent(_gameEventToInvoke);
            }
        }
    }
}
