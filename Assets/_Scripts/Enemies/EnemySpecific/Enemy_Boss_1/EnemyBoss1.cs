using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss1 : Entity
{
    public EBOSS1_MoveState moveState { get; private set; }
    public EBOSS1_IdleState idleState { get; private set; }
    public EBOSS1_DetectedState detectedState { get; private set; }
    public EBOSS1_MeeleAttackState meeleAttackState{ get; private set; }
    public EBOSS1_LookForPlayerState lookForPlayerState { get; private set; }
    public EBOSS1_DeadState deadState { get; private set;}
    public EBOSS1_RangerAttack1State rangerAttack1State { get; private set; }
    public EBOSS1_RangerAttack2State rangerAttack2State { get; private set; }

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdieState idleStateData;
    [SerializeField]
    private D_PlayerDeceted playerDetectesStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    private D_RangeAttaclState rangeAttacl1StateData;
    [SerializeField]
    private D_RangeAttaclState rangeAttacl2StateData;

    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    private Transform rangedAttackPosition;
    [SerializeField]
    private Transform SkillAttackPosition;


    public override void Awake()
    {
        base.Awake();
        moveState = new EBOSS1_MoveState(this, stateMachine, "Move", moveStateData, this);
        idleState = new EBOSS1_IdleState(this, stateMachine, "Idle", idleStateData, this);
        detectedState = new EBOSS1_DetectedState(this, stateMachine, "Detected", playerDetectesStateData, this);
        meeleAttackState = new EBOSS1_MeeleAttackState(this, stateMachine, "MeeleAttack", meleeAttackPosition, meleeAttackStateData, this);
        lookForPlayerState = new EBOSS1_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        deadState = new EBOSS1_DeadState(this, stateMachine, "Death", deadStateData, this);
        rangerAttack1State = new EBOSS1_RangerAttack1State(this, stateMachine, "RangerAttack1", rangedAttackPosition, rangeAttacl1StateData, this);
        rangerAttack2State = new EBOSS1_RangerAttack2State(this, stateMachine, "RangerAttack2", SkillAttackPosition, rangeAttacl2StateData, this);
    }
    private void Start()
    {
        stateMachine.Initialize(lookForPlayerState);
    }


    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
   
}
