using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UzayGemisi : UzayObjesi
{
    public bool thrusting;
    public float turning;

    public UnityEvent GemiPatladý;

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

    public void KursunAtesEt()
    {
        UzayKursunu kursun = UzayKursunHavuzu.Instance.GetKursun();
        if (kursun != null)
        {
            kursun.transform.position = transform.position;
            kursun.transform.rotation = transform.rotation;
            kursun.AtesHazirligi(transform.up);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7) // 7 nolu layer meteor
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;

            GorselYonetici.Instance.PatlamaOlunca.Invoke(transform);
            GemiPatladý.Invoke();
            gameObject.SetActive(false);
        }
    }
}
