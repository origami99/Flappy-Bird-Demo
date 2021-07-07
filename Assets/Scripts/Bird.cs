using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static event Action OnDeath;
    public static event Action OnScore;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private float _yBound;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _flapSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _scoreSound;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _rigidbody.position.y < _yBound)
        {
            Flap();
        }
    }

    private void OnCollisionEnter2D()
    {
        OnDeath?.Invoke();

        _audioSource.PlayOneShot(_hitSound);

        Time.timeScale = 0f;
    }

    private void OnTriggerEnter2D()
    {
        OnScore?.Invoke();

        _audioSource.PlayOneShot(_scoreSound);
    }

    private void Flap()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _force);

        _audioSource.PlayOneShot(_flapSound);
    }
}
