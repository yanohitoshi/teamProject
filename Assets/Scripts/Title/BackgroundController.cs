using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    //スクロール速度
    [SerializeField]
    float scrollSpeed;

    Vector2 spriteSize;
    Vector2 direction;

    public void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = spriteRenderer.bounds.size;
        direction = new Vector2(spriteSize.x / 2.0f - -(spriteSize.x / 2.0f), -(spriteSize.y / 2.0f) - spriteSize.y / 2.0f);
        direction.Normalize();
    }

    public void Run()
    {
        transform.Translate(direction.x * scrollSpeed * Time.deltaTime, direction.y * scrollSpeed * Time.deltaTime, 0);
        if (transform.position.y < -spriteSize.y)
        {
            transform.position = new Vector3(-spriteSize.x, spriteSize.y, 145);
        }
    }
}
