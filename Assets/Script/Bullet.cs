using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _timeDeSpawn = 5f;


    private Rigidbody2D _rb2D;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _timeDeSpawn);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy _enemy = other.gameObject.GetComponentInParent<Enemy>();
        if (_enemy != null)
        {
            Destroy(_enemy.gameObject);
            Destroy(gameObject);
        }
    }

    public void Born(Vector2 force)
    {
        _rb2D.AddForce(force * _speed, ForceMode2D.Impulse);
    }
}
