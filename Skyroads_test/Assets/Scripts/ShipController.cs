using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _shipPlayer;

    public float _speed = 15f;
    public float _verticalSpeed = 1.5f;

    private GameEnd _end;

    public static ShipController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        _rb = GetComponent<Rigidbody>();
        _end = GetComponent<GameEnd>();
    }

    private void FixedUpdate()
    {
        float _hor = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector3(_hor, 0.0f, _verticalSpeed) * _speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.50f, 3.5f), transform.position.y, transform.position.z);
        transform.rotation = Quaternion.AngleAxis(-35 * _hor, transform.forward);       
    }

    private void Update()    
    {
        SetAcceleration();
    }

    private void SetAcceleration()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _verticalSpeed *= 2;
        else if (Input.GetKeyUp(KeyCode.Space)) _verticalSpeed /= 2;
    }

    private void OnCollisionEnter()
    {
        _shipPlayer.SetActive(false);
        _end.GameOver();
    }
}