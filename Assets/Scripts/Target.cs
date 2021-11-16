using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    Rigidbody targetRb;
    public float xRange=1.95f;
    public float minSpeed = 14;
    public float maxSpeed = 16;
    public float maxTorque = 10;
    public float ySpawnPos=-2;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        SetPositionAndForce();
    }

    private void SetPositionAndForce()
    {
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);

        targetRb.AddTorque(Random.RandomRange(-maxTorque, maxTorque),
         Random.RandomRange(-maxTorque, maxTorque),
         Random.RandomRange(-maxTorque, maxTorque), ForceMode.Impulse);
    }

    private void OnMouseDown() {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Sensor")) gameObject.SetActive(false);
    }
    void Update()
    {

    }
}
