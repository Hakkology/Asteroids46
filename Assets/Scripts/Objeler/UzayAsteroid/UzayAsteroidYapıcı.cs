using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayAsteroidYapıcı
{

    private UzayAsteroid asteroidInstance;
    private UzayAsteroid asteroidPrefab;

    public UzayAsteroidYapıcı(UzayAsteroid asteroid)
    {
        asteroidPrefab = asteroid;
    }

    public UzayAsteroidYapıcı AsteroidOlustur(Vector3 position, Quaternion rotation)
    {
        asteroidInstance = MonoBehaviour.Instantiate(asteroidPrefab, position, rotation);
        asteroidInstance.gameObject.SetActive(true);
        return this;
    }

    public UzayAsteroidYapıcı AsteroidBoyutAyarla(float boyut)
    {
        asteroidInstance.buyukluk = boyut;
        asteroidInstance.transform.localScale = Vector3.one * boyut;
        return this;
    }

    public UzayAsteroidYapıcı AsteroidYonBelirle(Vector2 direction)
    {
        asteroidInstance.AsteroidHareket(direction);
        return this;
    }

    public UzayAsteroid Olustur()
    {
        return asteroidInstance;
    }
}
