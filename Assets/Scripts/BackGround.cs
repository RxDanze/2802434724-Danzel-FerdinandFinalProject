using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    private float length;
    private float startpos;
    [SerializeField]private float xstart = -8.9f;
    [SerializeField]private float xend = 8.9f;
    [SerializeField]private float parallaxEffect;
    [SerializeField] private float speed = -2f;
    [SerializeField] private float offset = 0.5f;

    private void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void move()
    {
        Vector2 newpos = new Vector2(transform.position.x + speed * Time.deltaTime * (1 - parallaxEffect), transform.position.y);
        transform.position = newpos;
    }

    private void FixedUpdate()
    {
        move();

        if(transform.position.x + (length/2) < xstart)
        {
            Vector2 newpos = new Vector2(xend + (length/2) + offset, transform.position.y);
            transform.position = newpos;
        }
    }
}
