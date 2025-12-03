using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _flapForce = 5f;
    private bool _isAlive = true;
    [SerializeField]private float _ybounds = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void Flap(){
        if (_isAlive){
            _rb2d.velocity = Vector2.zero;
            _rb2d.velocity = Vector2.up * _flapForce;
        }
    }

    public void Die()
    {
        if (!_isAlive)
        {
            return;
        }
        _isAlive = false;
        Debug.Log("Die");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
            Flap();
        }
        if (_isAlive && transform.position.y < _ybounds)
        {
            Die();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        Die();
    }
}
