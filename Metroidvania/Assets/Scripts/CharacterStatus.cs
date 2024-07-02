using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    // 상태 값 설정

    public int hp = 10;                         // 플레이어 생명
    public bool invincible = false;             // 무적 상태
    public bool canMove = true;                 // 이동 가능 상태
    public bool isDashing = false;              // 대시 상태
    public bool canDash = true;                 // 대시 가능 상태 여부
    public float mDashForce = 25f;              // 대시 힘의 양

    //=========================================================================================

    // 타이머 설정 값

    // MonoBehaviour를 상속받지 않은 클래스 이므로 new로 생성
    public Timer stunTimer = new Timer(0.25f);          // 스턴 타이머 0.25초 할당
    public Timer invincibilityTimer = new Timer(1f);    // 무적 타이머 1초
    public Timer moveTimer = new Timer(0f);             
    public Timer checkTimer = new Timer(0f);
    public Timer endSlidingTimer = new Timer(0f);
    public Timer deadTimer = new Timer(1.5f);
    public Timer dashCooldownTimer = new Timer(0.6f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 타이머 업데이트

        float deltaTime = Time.deltaTime;
        stunTimer.Update(deltaTime);
        invincibilityTimer.Update(deltaTime);
        moveTimer.Update(deltaTime);
        checkTimer.Update(deltaTime);
        endSlidingTimer.Update(deltaTime);
        deadTimer.Update(deltaTime);
        dashCooldownTimer.Update(deltaTime);

        //==================================================================

        // 타이머 상태 체크

        if (!stunTimer.IsRunning())                         // 스턴 타이머 동작 체크 (스턴이 아니면)
        {
            canMove = true;                                 // 움직일 수 있음
        }

        if (!invincibilityTimer.IsRunning())                // 무적이 아니면
        {
            invincible = false;                             // 무적 상태가 아님
        }

        if (!moveTimer.IsRunning())                         // 이동중이 아니라면
        {
            canMove = true;                                 // 움직일 수 있음
        }

        if (isDashing && !dashCooldownTimer.IsRunning())    // 대시 중이고 대시 타이머가 끝났다면
        {
            isDashing = false;                              // 대시를 끝냄
            canMove = true;                                 // 움직일 수 있음
            canDash = true;                                 // 다시 대시를 할 수 있음
        }

        if (deadTimer.GetRemainingTime() <= 0)
        {
            // 씬처리 등등 해준다
        }
    }

    public void StartDash(float dashDuration)
    {
        //animator.SetBool("IsDashing", true)
        isDashing = true;
        canMove = false;
        canDash = false;
        dashCooldownTimer = new Timer(dashDuration);
        dashCooldownTimer.Start();
    }

    public void ApplyDamage(int damage, Vector3 position)
    {
        if (!invincible)
        {
            //animator.SetBool("Hit", true)
            hp -= damage;

            if (hp <= 0)
            {
                deadTimer.Start();
            }
            else
            {
                stunTimer.Start();
                invincibilityTimer.Start();
            }
        }
    }
}
