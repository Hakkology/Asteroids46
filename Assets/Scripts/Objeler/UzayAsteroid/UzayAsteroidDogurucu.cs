using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayAsteroidDogurucu : MonoBehaviour
{
    public static UzayAsteroidDogurucu Instance { get; private set; }

    public UzayAsteroid asteroidPrefab;

    public float dogurmaGecikmesi = 0;
    public float dogurmaSýklýgý = 2;
    public float dogurmaSayýsý = 2;
    public float dogurmaUzaklýgý = 10f;

    public float sapmaAcisi = 15f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating(nameof(AsteroidDogur), dogurmaGecikmesi, dogurmaSýklýgý);
    }

    private void AsteroidDogur()
    {
        for (int i = 0; i < dogurmaSayýsý; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * dogurmaUzaklýgý;
            Vector3 spawnPoint = transform.position + spawnDirection;

            float variance = Random.Range(-sapmaAcisi, sapmaAcisi);
            Quaternion spawnRotation = Quaternion.AngleAxis(variance, Vector3.forward);

            new UzayAsteroidYapýcý(asteroidPrefab)
                .AsteroidOlustur(spawnPoint, spawnRotation)
                .AsteroidBoyutAyarla(Random.Range(asteroidPrefab.minBuyukluk, asteroidPrefab.maxBuyukluk))
                .AsteroidYonBelirle(spawnRotation * -spawnDirection)
                .Olustur();

            //UzayAsteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, spawnRotation);
            //asteroid.buyukluk = Random.Range(asteroid.minBuyukluk, asteroid.maxBuyukluk);
            //asteroid.AsteroidHareket(spawnRotation * -spawnDirection);
        }
    }
}
