using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterMovement controller;
    public Animator animator;

    public float runSpeed = 40.0f;              // 이동 속도 값 설정
    float horizontalMove = 0f;
    bool jump = false;
    bool dash = false;

    void Update()                   // 키 입력을 받음
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));          // 절대값

        if (Input.GetKeyDown(KeyCode.Z))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            dash = true;
        }
    }

    public void OnFall()                        // 떨어짐 처리 Event
    {
        //animator.SetBool("IsJumping", true);
    }

    public void OnLanding()                     // 착지 처리 Event
    {
        //animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()                      // 실질적으로 움직이게 해주는 부분
    {
        // 캐릭터 움직임 구현할 함수
        //controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);

        jump = false;
        dash = false;
    }
}
