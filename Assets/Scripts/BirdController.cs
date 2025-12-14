using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _flapForce = 5f;
    private bool _isAlive = true;

    private Animator birdAnimator;
    [SerializeField]private float _ybounds = -5f;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        birdAnimator = GetComponent<Animator>();
    }

    public void Flap(){
        if (_isAlive){
            _rb2d.velocity = Vector2.zero;
            _rb2d.velocity = Vector2.up * _flapForce;
            birdAnimator.SetTrigger("Flap");
        }
    }

    public void Die()
    {
        if (!_isAlive)
        {
            return;
        }
        _isAlive = false;
        GameManager.Instance.GameOver();
    }

    void Update()
    {
        if(!GameManager.Instance.IsGameStarted())
        {
            return;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime * 1);

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.Euler(0, 0, 50);
            Flap();
        }

        if (transform.position.y < _ybounds)
        {
            Die();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        Die();
    }
}
