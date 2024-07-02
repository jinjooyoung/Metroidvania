using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndParamBehaviour : StateMachineBehaviour
{
    public string parameter = "IsAttacking";                    // 애니메이터에서 저장한 파라미터 값을 저장

    // 상속받은 StateMachineBehaviour에 있는 가상함수를 사용하려면 override (오버라이드) 를 해줘야함
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 애니메이션이 종료되고 전환되는 시점에서 선언한 애니메이션 파라미터 값은 true -> false 시킨다.
        animator.SetBool(parameter, false);
    }
}
