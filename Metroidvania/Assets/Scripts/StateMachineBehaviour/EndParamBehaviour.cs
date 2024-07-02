using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndParamBehaviour : StateMachineBehaviour
{
    public string parameter = "IsAttacking";                    // �ִϸ����Ϳ��� ������ �Ķ���� ���� ����

    // ��ӹ��� StateMachineBehaviour�� �ִ� �����Լ��� ����Ϸ��� override (�������̵�) �� �������
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // �ִϸ��̼��� ����ǰ� ��ȯ�Ǵ� �������� ������ �ִϸ��̼� �Ķ���� ���� true -> false ��Ų��.
        animator.SetBool(parameter, false);
    }
}
