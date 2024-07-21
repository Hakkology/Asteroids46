using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GorselYonetici : MonoBehaviour
{
    public static GorselYonetici Instance { get; private set; }

    public ParticleSystem patlama;
    public UnityEvent<Transform> PatlamaOlunca;

    private Transform location;

    void Awake() => Instance = this;

    void Start() => PatlamaOlunca.AddListener(Kabooom);


    public void Kabooom(Transform location)
    {
        ParticleSystem patla = Instantiate(patlama, location.position, Quaternion.identity);
        patla.Play();
        Destroy(patla.gameObject, patla.main.duration);
    }
}
