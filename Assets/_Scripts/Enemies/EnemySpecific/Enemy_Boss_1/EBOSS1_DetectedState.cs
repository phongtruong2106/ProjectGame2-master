using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBOSS1_DetectedState : PlayerDecetedState
{
    private EnemyBoss1 _enemyBoss1;
    public EBOSS1_DetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDeceted stateData, EnemyBoss1 enemyBoss1) : base(entity, stateMachine, animBoolName, stateData)
    {
       this._enemyBoss1 = enemyBoss1;
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
        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(_enemyBoss1.meeleAttackState);
        }
        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(_enemyBoss1.rangerAttack1State);
        }
        else if (!isPlayerInMaxArgnRange) //trang thai nhin thay ngioi choi
        {
            stateMachine.ChangeState(_enemyBoss1.lookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
