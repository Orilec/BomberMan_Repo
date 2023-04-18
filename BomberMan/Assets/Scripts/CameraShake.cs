using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private float shakeDuration, shakeMagnitude, fadingSpeed, shakeTimer;
    private Vector3 initialPosition;


    private void Start()
    {
        initialPosition = transform.position;
    }
    private void Update()
    {
        if (shakeTimer > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeTimer -= Time.deltaTime * fadingSpeed;
        }
        else
        {
            shakeTimer = 0f;
            transform.localPosition = initialPosition;
        }
    }
    public void TriggerShake()
    {
        shakeTimer = shakeDuration;
    }
}
