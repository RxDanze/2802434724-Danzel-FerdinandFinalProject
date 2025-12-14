using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleBase : MonoBehaviour
{
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float destroyXpos = -10f;

    public abstract void Move();

    protected void CheckDestroy() {
        if(transform.position.x < destroyXpos) {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
        CheckDestroy();
    }
}
