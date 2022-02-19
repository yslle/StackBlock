using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public float speed = 3f;

    bool switc = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (switc)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (!switc)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (transform.position.x >= 3f)
        {
            switc = false;
        }
        if (transform.position.x <= -3f)
        {
            switc = true;
        }
    }

}

