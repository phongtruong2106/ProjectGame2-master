using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBOSS1_MeeleAttackState : MeleeAttackState
{
    private EnemyBoss1 _enemyBoss1;
    public EBOSS1_MeeleAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, EnemyBoss1 enemyBoss1) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        _enemyBoss1 = enemyBoss1;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (isAnimationFinished)
        {
            if (isPlayerInMinArgoRange)
            {
                stateMachine.ChangeState(_enemyBoss1.detectedState);
            }
            else if (!isPlayerInMinArgoRange)
            {
                stateMachine.ChangeState(_enemyBoss1.lookForPlayerState);
            }
        }
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
