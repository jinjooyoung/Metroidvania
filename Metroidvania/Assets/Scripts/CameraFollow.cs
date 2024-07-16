using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2.0f;            // 카메라가 캐릭터를 따라가는 스피드
    public Transform target;                    // 타겟 트랜스폼

    private Transform camTransform;             // 카메라의 트랜스폼

    public float shakeDuration = 0.0f;
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;                        // 원본 위치

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
