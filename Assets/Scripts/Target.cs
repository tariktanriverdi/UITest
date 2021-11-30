using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    public float xRange = 1.95f;
    public float minSpeed = 14;
    public float maxSpeed = 16;
    public float maxTorque = 10;
    public float ySpawnPos = -2;
    public int pointValue = 1;
    public int effectIndex = 3;
    private void Awake()
    {
        targetRb = GetComponent<Rigidbody>();
    }
    void Start()
    {

        //SetPositionAndForce();
    }
    private void OnEnable()
    {
        Debug.Log("On enabled");

        SetPositionAndForce();
    }

    public void SetPositionAndForce()
    {
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
        targetRb.velocity = Vector3.zero;
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);

        targetRb.AddTorque(Random.RandomRange(-maxTorque, maxTorque),
         Random.RandomRange(-maxTorque, maxTorque),
         Random.RandomRange(-maxTorque, maxTorque), ForceMode.Impulse);
    }

    private void OnMouseDown()
    {   
        if(gameObject.CompareTag("Bad")) GameManager.Instance.GameOver();
        GameObject particleSystem = ObjectPooler.SharedInstance.GetPooledObject(effectIndex);
        if (particleSystem!=null)
        {
            particleSystem.transform.position = transform.position;
            
            StartCoroutine(SetEffectTime(particleSystem));
        }


        //   particleSystem.SetActive(false);
        gameObject.SetActive(false);
        GameManager.Instance.UpdateScore(pointValue);

    }

    IEnumerator SetEffectTime(GameObject go)
    {  go.SetActive(true);
        yield return new WaitForSeconds(1);
        go.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Sensor")) 
        if(!gameObject.CompareTag("Bad")) GameManager.Instance.GameOver();
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (transform.position.y < -20) gameObject.SetActive(false);
    }
}
