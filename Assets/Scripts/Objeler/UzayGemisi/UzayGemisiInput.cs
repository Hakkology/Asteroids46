using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiInput : MonoBehaviour
{
    private UzayGemisi uzayGemisi;
    private UzayGemisiKeyboard keyboard;
    private UzayGemisiTouch touch;

    private void Awake()
    {
        uzayGemisi = GetComponent<UzayGemisi>();
        keyboard = new UzayGemisiKeyboard(uzayGemisi);
        touch = new UzayGemisiTouch(uzayGemisi);
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
