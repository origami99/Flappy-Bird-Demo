using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static event Action OnDeath;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private float _yBound;

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

        Time.timeScale = 0f;
    }

    private void Flap()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _force);
    }
}
