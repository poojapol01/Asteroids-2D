using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rg;
    private bool _thrusting;
    private float _turnDirection;
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    public Bullet bulletPrefab;

    private void Awake()
    {
        _rg = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow); 

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = -1.0f;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = 1.0f;
        }
        else
        {
            _turnDirection = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (_thrusting)
        {
            _rg.AddForce(this.transform.up * thrustSpeed);
        }
        else if(_turnDirection != 0.0f)
        {
            _rg.AddTorque(_turnDirection * turnSpeed);
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            Debug.Log("Collision");
            _rg.velocity = Vector3.zero;
            _rg.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
