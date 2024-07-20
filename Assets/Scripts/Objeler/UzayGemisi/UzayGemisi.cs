using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisi : UzayObjesi
{
    public bool thrusting;
    public float turning;

    [SerializeField] public float turnSpeed;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        HandleEvents();
    }

    private void HandleEvents()
    {
        if (thrusting)
        {
            rb.AddForce(this.transform.up * speed);
        }
        if (turning != 0)
        {
            rb.AddTorque(turning * turnSpeed);
        }
    }
}
