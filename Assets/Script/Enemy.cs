using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private static PlayerShooterController _playerShooterController;

    private BoxCollider2D _box2D;
    private Rigidbody2D _rb2D;

    private float _deltaMove;

    void Awake()
    {
        _box2D = GetComponent<BoxCollider2D>();
        _rb2D = GetComponent<Rigidbody2D>();
        //Velocità per frame
        _deltaMove = Random.Range(1f, 3f) * Time.deltaTime;

        if (_playerShooterController == null)
        {
            _playerShooterController = FindAnyObjectByType<PlayerShooterController>();
        }
        _playerShooterController.AddEnemyInList(this);

        //Posizione iniziale
        _rb2D.MovePosition(Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)) * new Vector3(Random.Range(15f, 20f), 0f) + _playerShooterController.transform.position);
    }

    private void ActiveCollider()
    {
        _box2D.enabled = true;
    }

    void Start()
    {
        InvokeRepeating("ActiveCollider", 0.5f, 0f);
    }

    private void EnemyMovement()
    {
        _rb2D.MovePosition(Vector2.MoveTowards(_rb2D.position, _playerShooterController.transform.position, _deltaMove));
    }

    void Update()
    {
        EnemyMovement();
    }

    void OnDestroy()
    {
        _playerShooterController.RemoveEnemyInList(this);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            player.gameObject.SetActive(false);
        }
    }
}
