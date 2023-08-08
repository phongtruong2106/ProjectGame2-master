using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementState : State
{

    protected BossMovement bossMovement { get => bossMovement ?? Core.GetCoreComponent(ref bossmovement); }
    private CollisionSenses CollisionSenses { get => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses); }
    private CollisionSenses collisionSenses;
    private BossMovement bossmovement;
    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinArgoRange;
    public BossMovementState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        //kiem tra thuc the wall , ledge  
        isDetectingLedge = CollisionSenses.LedgeVertical;
        isDetectingWall = CollisionSenses.WallFront;
        isPlayerInMinArgoRange = entity.checkPlayerInMinAgroRange();
    }
    public override void Enter()
    {
        base.Enter();
        bossMovement?.SetVelocityX(stateData.movementSpeed * bossMovement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        bossMovement?.SetVelocityX(stateData.movementSpeed * bossMovement.FacingDirection);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
