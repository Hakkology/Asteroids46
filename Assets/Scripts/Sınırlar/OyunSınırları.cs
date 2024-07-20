using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OyunSınırları : MonoBehaviour
{
    public float colliderGenislik = 1;
    public float colliderOffset = .5f;

    private void Start()
    {
        ColliderSınırlarınıCiz();
    }

    private void ColliderSınırlarınıCiz()
    {
        Vector2 solAltKose = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
        Vector2 sagUstKose = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        YatayColliderCiz(solAltKose.x, sagUstKose.x, sagUstKose.y + colliderOffset);
        YatayColliderCiz(solAltKose.x, sagUstKose.x, solAltKose.y - colliderOffset);

        DikeyColliderCiz(solAltKose.y, sagUstKose.y, solAltKose.x - colliderOffset);
        DikeyColliderCiz(solAltKose.y, sagUstKose.y, sagUstKose.x + colliderOffset);
    }

    void YatayColliderCiz(float startX, float endX, float positionY)
    {
        GameObject boundary = new GameObject("YataySınır");
        boundary.transform.position = new Vector3((startX + endX) /2, positionY, 0);
        //boundary.transform.parent = transform;
        BoxCollider2D collider = boundary.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(endX - startX + colliderOffset, colliderGenislik);
        //collider.isTrigger = true;
    }
    void DikeyColliderCiz(float startY, float endY, float positionX)
    {
        GameObject boundary = new GameObject("DikeySubur");
        boundary.transform.position = new Vector3(positionX, (startY + endY)/2, 0);
        //boundary.transform.parent = transform;
        BoxCollider2D collider = boundary.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(colliderGenislik, endY - startY + colliderOffset);
        //collider.isTrigger = true;
    }
}
