using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunYoneticisi : MonoBehaviour
{
    public static OyunYoneticisi Instance { get; private set; }

    public UzayGemisi gemi;

    public int gemiCan = 3;
    private int gemiSkor = 0;

    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        gemi.GemiPatladý.AddListener(GemiOldu);
    }

    void GemiOldu()
    {
        gemiCan--;

        if (gemiCan <= 0)
        {
            OyunuBitir();
        }
        else
        {
            Invoke(nameof(GemiyiBirDahaYap), 2);
        }
    }

    private void GemiyiBirDahaYap()
    {
        gemi.transform.position = Vector2.zero;
        gemi.gameObject.SetActive(true);
    }

    private void OyunuBitir()
    {
        // oyun bitirme
    }
}
