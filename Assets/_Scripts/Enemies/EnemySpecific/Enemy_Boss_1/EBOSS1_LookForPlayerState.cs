using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBOSS1_LookForPlayerState : LookForPlayerState
{
    private EnemyBoss1 _enemyBoss1;
    public EBOSS1_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData, EnemyBoss1 enemyBoss1) : base(entity, stateMachine, animBoolName, stateData)
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInMinArgoRange)
        {
            stateMachine.ChangeState(_enemyBoss1.detectedState);
        }
        else if(isAllTurnsTimeDone)
        {
            stateMachine.ChangeState(_enemyBoss1.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
