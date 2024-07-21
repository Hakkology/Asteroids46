using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UzayGemisiInput : MonoBehaviour
{
    private UzayGemisi uzayGemisi;
    private UzayGemisiKeyboard keyboard;
    private UzayGemisiTouch touch;

    public Button atesButonu;

    private void Awake()
    {
        uzayGemisi = GetComponent<UzayGemisi>();
        keyboard = new UzayGemisiKeyboard(uzayGemisi);
        touch = new UzayGemisiTouch(uzayGemisi, atesButonu);
    }

    private void Update()
    {
        if (Application.isMobilePlatform)
        {
            touch.HandleControls();
        }
        else
        {
            keyboard.HandleControls();
        }
    }
}
