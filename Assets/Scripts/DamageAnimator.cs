using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DamageAnimator : MonoBehaviour
{
    [SerializeField] private Camera _firstCamera;
    [SerializeField] private ParticleSystem _effectPrefab;
    [SerializeField] private float _distance = 100f;

    public event Action<RaycastHit> PlayEffect;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = _firstCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _distance))
            {
                ParticleSystem newEffect = Instantiate(_effectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                newEffect.Play();

                PlayEffect?.Invoke(hit);
            }
        }
    }
}