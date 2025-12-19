using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastHitEmitter : MonoBehaviour
{
    [SerializeField] private Camera _firstCamera;
    [SerializeField] private float _distance = 100f;

    public event Action<RaycastHit> OnHitEmitter;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = _firstCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _distance))          
                OnHitEmitter?.Invoke(hit);
        }
    }
}