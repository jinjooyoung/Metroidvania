using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2.0f;            // ī�޶� ĳ���͸� ���󰡴� ���ǵ�
    public Transform target;                    // Ÿ�� Ʈ������

    private Transform camTransform;             // ī�޶��� Ʈ������

    public float shakeDuration = 0.0f;
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;                        // ���� ��ġ

    private void OnEnable()
    {
        //originalPos = camTransform.localPosition;
    }

    void Update()
    {
        Vector3 newPosition = target.position;
        newPosition.z = -10;
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
