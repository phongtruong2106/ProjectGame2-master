using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBOSS1_IdleState : IdieState
{
    private EnemyBoss1 _enemyBoss1;
    public EBOSS1_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdieState stateData, EnemyBoss1 enemyBoss1) : base(entity, stateMachine, animBoolName, stateData)
    {
        this._enemyBoss1 = enemyBoss1;
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isPlayerInMinArgnRange)
        {
            stateMachine.ChangeState(_enemyBoss1.detectedState);
        }
        else if(isIdleTimeOver)
        {
            stateMachine.ChangeState(_enemyBoss1.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
