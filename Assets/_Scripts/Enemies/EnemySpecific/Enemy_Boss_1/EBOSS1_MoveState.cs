using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBOSS1_MoveState : MoveState
{
    private EnemyBoss1 enemyBoss1;
    public EBOSS1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, EnemyBoss1 enemyBoss1) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemyBoss1 = enemyBoss1;
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
        if(isPlayerInMinArgoRange)
        {
           stateMachine.ChangeState(enemyBoss1.detectedState);
        }
        else if(isDetectingWall || !isDetectingLedge)
        {
            enemyBoss1.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemyBoss1.idleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
