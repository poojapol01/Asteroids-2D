using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    public float size = 1.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        _rigidbody.mass = this.size;
    }
}
