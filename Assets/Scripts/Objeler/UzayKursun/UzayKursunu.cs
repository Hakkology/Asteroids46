using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayKursunu : UzayObjesi
{
    [SerializeField] private int kursunSuresi;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Start()
    {
        base.Start();
        rb.drag = 0;
    }

    protected override void Update()
    {
        base.Update();
    }

    public void AtesHazirligi(Vector2 direction)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(direction * speed);
        Invoke(nameof(HavuzaDonder), kursunSuresi);
    }

    private void HavuzaDonder()
    {
        UzayKursunHavuzu.Instance.DondurKursun(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GorselYonetici.Instance.PatlamaOlunca.Invoke(transform);
        HavuzaDonder();
    }
}
