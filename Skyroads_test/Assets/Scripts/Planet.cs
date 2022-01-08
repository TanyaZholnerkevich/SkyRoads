using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public ShipController _shipController;

    private void Start()
    {
        _shipController = ShipController.Instance;
    }
    private void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * _shipController._verticalSpeed * _shipController._speed * Time.deltaTime);
    }
}
