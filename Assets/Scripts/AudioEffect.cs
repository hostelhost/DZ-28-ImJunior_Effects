using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private DamageAnimator _damageAnimator;

    private void OnEnable()
    {
        _damageAnimator.PlayEffect += PlayEffect;
    }

    private void OnDisable()
    {
        _damageAnimator.PlayEffect -= PlayEffect;
    }

    private void PlayEffect(RaycastHit hit)
    {
        if (_audioClips.Length > 0)
            AudioSource.PlayClipAtPoint(_audioClips[Random.Range(0, _audioClips.Length)], hit.point);
    }
}