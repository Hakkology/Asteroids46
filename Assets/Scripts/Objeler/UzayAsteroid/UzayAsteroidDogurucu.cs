using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayAsteroidDogurucu : MonoBehaviour
{
    public static UzayAsteroidDogurucu Instance { get; private set; }

    public UzayAsteroid asteroidPrefab;

    public float dogurmaGecikmesi = 0;
    public float dogurmaS�kl�g� = 2;
    public float dogurmaSay�s� = 2;
    public float dogurmaUzakl�g� = 10f;

    public float sapmaAcisi = 15f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating(nameof(AsteroidDogur), dogurmaGecikmesi, dogurmaS�kl�g�);
    }

    private void AsteroidDogur()
    {
        for (int i = 0; i < dogurmaSay�s�; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * dogurmaUzakl�g�;
            Vector3 spawnPoint = transform.position + spawnDirection;

            float variance = Random.Range(-sapmaAcisi, sapmaAcisi);
            Quaternion spawnRotation = Quaternion.AngleAxis(variance, Vector3.forward);

            new UzayAsteroidYap�c�(asteroidPrefab)
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
