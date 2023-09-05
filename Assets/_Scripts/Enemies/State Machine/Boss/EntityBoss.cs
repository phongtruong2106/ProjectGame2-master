
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EntityBoss : MonoBehaviour
{
    protected Movement Movement { get => movement ?? Core.GetCoreComponent(ref movement); }
    private Movement movement;
    public FiniteStateMachine stateMachine;

    public D_Entity_Boss entityBossData;

    //lop thuc the
    public Animator anim { get; private set; }
    public AnimationToStateMachine atsm { get; private set; }
    public int lastDamageDirection { get; private set; }
    public Core Core { get; private set; }

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    private Transform groundCheck; //kiem tra mat dat

    private float currentHealth_Boss;
    private float currentStunResistance_Boss;
    private float lastDamageTime;
    private Vector2 velocityWorkspace;

    protected bool isStunned;
    protected bool isDead;

    //tat ca nhung enemy co the override lai 
    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();

        currentHealth_Boss = entityBossData.maxHealth;
        currentStunResistance_Boss = entityBossData.stunResistance;// kha nag chong choang 

        //   aliveGO  = transform.Find("Alive").gameObject; //khong can phai khai bao
        anim = GetComponent<Animator>();
        atsm = GetComponent<AnimationToStateMachine>();

        stateMachine = new FiniteStateMachine();
    }

    [PunRPC]
    public virtual void Update()
    {
        Core.LogicUpDate();
        stateMachine.currentState.LogicUpdate();
        anim.SetFloat("yVelocity", Movement.RB.velocity.y);
        if (Time.time >= lastDamageTime + entityBossData.stunRecoveryTime)
        {
            ResetStunResistanceBoss();
        }
        PhotonView photonView = PhotonView.Get(this);

        // Gọi RPC để thông báo enemy đã chết cho các máy chơi khác
        photonView.RPC("State", RpcTarget.All);

    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }


    //tao ham phat hien player , cach hoat dong giong nhu Checkwall va checkLedge
    public virtual bool checkPlayerRangeSkillAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityBossData.rangeskillArgoDistance, entityBossData.whatIsPlayer);
    }
    public virtual bool checkPlayerInMinAgroRangeBoss()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityBossData.minArgoDistance, entityBossData.whatIsPlayer);
    }

    public virtual bool checkPlayerInMaxAgroRangeBoss()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityBossData.maxArgoDistance, entityBossData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInCloseRangeActionBoss()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityBossData.closeRangeActionDistace, entityBossData.whatIsPlayer);
    }

    public virtual void DamageHop(float velocity)
    {
        velocityWorkspace.Set(Movement.RB.velocity.x, velocity);
        Movement.RB.velocity = velocityWorkspace;
    }

    public virtual void ResetStunResistanceBoss()
    {
        //tro lai trang thai choang
        isStunned = false;
        currentStunResistance_Boss = entityBossData.stunResistance;
    }


    public virtual void OnDrawGizmos()
    {
        if (Core != null)
        {
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * Movement?.FacingDirection * entityBossData.wallCheckDistance));
            Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityBossData.ledgeCheckDistance));
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityBossData.closeRangeActionDistace), 0.05f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityBossData.maxArgoDistance), 0.05f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityBossData.minArgoDistance), 0.05f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityBossData.rangeskillArgoDistance), 0.05f);

        }

    }
}