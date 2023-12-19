using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    [SerializeField]
    private float Angle = 90f; // Скорость поворота двери в градусах в секунду
    [SerializeField]
    private Vector3 rotationAxis = Vector3.up; // Ось вращения (по умолчанию, ось Y)
    [SerializeField]
    private float smoothness = 5f; // Плавность вращения

    private bool isRotating = false; // Флаг, указывающий, в процессе ли вращения дверь
    private bool isOpen = false;
    new Transform transform;
    private void Start()
    {
        transform = GetComponent<Transform>();
    }
    public void Rotate()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateCoroutine());
        }
    }

    // Корутина для плавного вращения
    private IEnumerator RotateCoroutine()
    {
        isOpen = !isOpen;
        isRotating = true;
       
        
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if (isOpen)
        {
            endRotation = Quaternion.Euler(transform.rotation.eulerAngles + rotationAxis * Angle);
        }
        else
        {
            endRotation = Quaternion.Euler(transform.rotation.eulerAngles - rotationAxis * Angle);
        }
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime);
            elapsedTime += Time.deltaTime * smoothness;
            yield return null;
        }

        transform.rotation = endRotation; // Убедитесь, что доворачивание завершено
        isRotating = false;
    }
}

