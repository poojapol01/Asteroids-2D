using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float bulletSpeed = 500.0f;
    private float maxBulletLife = 10.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.bulletSpeed);

        Destroy(this.gameObject, maxBulletLife);
    }
}
