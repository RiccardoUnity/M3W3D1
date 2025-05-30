using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Vector2 _moveInput;
    private float _moveInputmMagnSqrt;
    [SerializeField] private float speed = 2f;

    //Componenti
    private Rigidbody2D _rb2D;
    
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private Vector2 Move()
    {
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _moveInputmMagnSqrt = _moveInput.sqrMagnitude;
        if (_moveInputmMagnSqrt > 1)
        {
            _moveInput /= Mathf.Sqrt(_moveInputmMagnSqrt);
        }
        return _moveInput * (speed * Time.deltaTime);
    }

    void Update()
    {
        _rb2D.MovePosition(_rb2D.position + Move());
    }
}
