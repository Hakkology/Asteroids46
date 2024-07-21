using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayAsteroid : UzayObjesi
{
    public Sprite[] asteroidler;
    protected SpriteRenderer sr;

    public float buyukluk = 1;
    public float minBuyukluk = .4f;
    public float maxBuyukluk = 2f;

    public float omur = 25f;

    protected override void Awake()
    {
        base.Awake();
        sr = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        rb.gravityScale = 0;
        rb.angularDrag = 0;
        rb.drag = 0;

        sr.sprite = asteroidler[Random.Range(0, asteroidler.Length)];

        transform.eulerAngles = new Vector3(0, 0, Random.value * 360);
        transform.localScale = Vector3.one * buyukluk;

        rb.mass = buyukluk;
    }

    public void AsteroidHareket(Vector2 direction)
    {
        rb.AddForce(direction * speed);
        Destroy(gameObject, 25);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (buyukluk *.5f > minBuyukluk)
            {
                AsteroidiBol();
                AsteroidiBol();
            }

            Destroy(gameObject);
        }
    }

    private void AsteroidiBol()
    {
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * .5f;


        new UzayAsteroidYapýcý(UzayAsteroidDogurucu.Instance.asteroidPrefab)
            .AsteroidOlustur(position, transform.rotation)
            .AsteroidBoyutAyarla(buyukluk * .5f)
            .AsteroidYonBelirle(Random.insideUnitCircle.normalized * speed)
            .Olustur();
    }
}
