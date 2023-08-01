using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBOSS1_DeadState : DeadState
{
    private EnemyBoss1 _enemyBoss1;

    public EBOSS1_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, EnemyBoss1 enemyBoss1) : base(entity, stateMachine, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
