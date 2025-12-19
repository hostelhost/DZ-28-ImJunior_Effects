using UnityEngine;

public class EffectTriggering : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectPrefab;
    [SerializeField] private RaycastHitEmitter _raycastHitEmitter;

    private void OnEnable()
    {
        _raycastHitEmitter.OnHitEmitter += PlayEffect;
    }

    private void OnDisable()
    {
        _raycastHitEmitter.OnHitEmitter -= PlayEffect;
    }

    private void PlayEffect(RaycastHit hit)
    {
        ParticleSystem newEffect = Instantiate(_effectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
        newEffect.Play();
    }
}