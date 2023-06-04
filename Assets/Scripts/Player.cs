using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rg;
    private bool _thrusting;
    private float _turnDirection;
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
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
    }

    private void FixedUpdate()
    {
        if (_thrusting)
        {
            rg.AddForce(this.transform.up * thrustSpeed);
        }
        else if(_turnDirection != 0.0f)
        {
            rg.AddTorque(_turnDirection * turnSpeed);
        }
    }
}
