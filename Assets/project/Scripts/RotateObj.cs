using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    [SerializeField]
    private float Angle = 90f; // �������� �������� ����� � �������� � �������
    [SerializeField]
    private Vector3 rotationAxis = Vector3.up; // ��� �������� (�� ���������, ��� Y)
    [SerializeField]
    private float smoothness = 5f; // ��������� ��������

    private bool isRotating = false; // ����, �����������, � �������� �� �������� �����
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

    // �������� ��� �������� ��������
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

        transform.rotation = endRotation; // ���������, ��� ������������� ���������
        isRotating = false;
    }
}

