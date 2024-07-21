using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayKursunHavuzu : MonoBehaviour
{
    public static UzayKursunHavuzu Instance { get; private set; }

    public UzayKursunu kursunPrefab;

    private Queue<UzayKursunu> kursunlar = new Queue<UzayKursunu>();

    [SerializeField] private int kursunHavuzBuyuklugu = 15;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            HavuzuBaslat();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void HavuzuBaslat()
    {
        for (int i = 0; i < kursunHavuzBuyuklugu; i++)
        {
            UzayKursunu kursun = Instantiate(kursunPrefab, transform);
            kursun.gameObject.SetActive(false);
            kursunlar.Enqueue(kursun);
        }
    }

    public UzayKursunu GetKursun()
    {
        if (kursunlar.Count > 0)
        {
            UzayKursunu kursun = kursunlar.Dequeue();
            kursun.gameObject.SetActive(true);
            return kursun;
        }
        else
        {
            Debug.Log("Havuzda kursun yok");
            return null;
        }
    }

    public void DondurKursun(UzayKursunu kursun)
    {
        kursun.gameObject.SetActive(false);
        kursunlar.Enqueue(kursun);
    }

}
