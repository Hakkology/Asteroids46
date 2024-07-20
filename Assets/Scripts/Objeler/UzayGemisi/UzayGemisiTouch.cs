using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UzayGemisiTouch 
{
    public UzayGemisi uzayGemisi;

    public UzayGemisiTouch(UzayGemisi uzayGemisi)
    {
        this.uzayGemisi = uzayGemisi;
    }

    public void HandleControls()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            uzayGemisi.thrusting = true;

            Vector2 directionToTouch = Camera.main.ScreenToWorldPoint(touch.position) - uzayGemisi.transform.position;
            float angleDifference = Mathf.DeltaAngle(
                uzayGemisi.transform.eulerAngles.z, 
                Mathf.Atan2(directionToTouch.y, directionToTouch.x) * Mathf.Rad2Deg - 90f
                );

            if (Mathf.Abs(angleDifference) > 1)
            {
                uzayGemisi.turning = Mathf.Max(uzayGemisi.turnSpeed, 
                    angleDifference / Mathf.Abs(angleDifference));
            }
            else
            {
                uzayGemisi.turning = 0;
                uzayGemisi.thrusting = false;
            }
        }
    }


}
