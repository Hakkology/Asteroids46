using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayObjesi : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Collider2D cd;

    [SerializeField] protected float speed;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
    }

    protected virtual void Start()
    {
        rb.gravityScale = 0;
        rb.drag = 1;
        rb.angularDrag = 1;
    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {

    }
}
