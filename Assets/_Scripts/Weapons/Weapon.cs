using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected SO_weaponData weaponData;
     protected Animator baseAnimator;
     protected Animator weaponAnimator;
     protected PlayerAttackState state;
     protected Core core;
    [SerializeField]
    private PhotonView view;


     protected int attackCounter; //bo dem 

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    protected virtual void Awake()
     {
        if(view.IsMine)
        {
            baseAnimator = transform.Find("Base").GetComponent<Animator>();
            weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

            gameObject.SetActive(false);
        }
        
     }

     public virtual void EnterWeapon()
     {
        if(view.IsMine)
        {
            gameObject.SetActive(true);
        
            if(attackCounter >= weaponData.amountOfAttacks) //neu toi so3 thi attackCounter tro ve 0
            {
               attackCounter = 0;
            }

            baseAnimator.SetBool("attack",true);
            weaponAnimator.SetBool("attack", true);


            baseAnimator.SetInteger("attackCounter", attackCounter);
            weaponAnimator.SetInteger("attackCounter", attackCounter); //thiet lap bo dem attack
        }
     }

     public virtual void ExitWeapon()
     {
            if(view.IsMine)
            {
                baseAnimator.SetBool("attack",false);
                weaponAnimator.SetBool("attack", false);
            
                attackCounter++; //cong don den so thu tu cua lan danh animation vidu 0 -> thuc hien don danh thu 1 , 0 tang len 1 -> thuc hien don danh thu 2

                gameObject.SetActive(false);

            }

        
     }

    #region Animation Trigger

    public virtual void AnimationFinishTrigger()
    {
        if(view.IsMine)
        {
            state.AnimationFinishTrigger();     

        }
    }

   public virtual void AnimationStartMovementTrigger()
   {
        if(view.IsMine)
        {
            state.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
        }
   }
   public virtual void AnimationStopMovementTrigger()
   {
        if(view.IsMine)
        {
            state.SetPlayerVelocity(0f);
        }
   }

   public virtual void AnimationTurnOffFlipTrigger()
   {
        if(view.IsMine)
        {
             state.SetFlipCheck(false);
        }
   }

   public virtual void AnimationTurnOnFlipTrigger()
   {
        if(view.IsMine)
        {
            state.SetFlipCheck(true);

        }
   }

   public virtual void AnimationActionTrigger()
   {
        if(view.IsMine)
        {
            state.SetFlipCheck(true);
        }
   }
    #endregion

    public void InitializeWeapon(PlayerAttackState state, Core core)
    {
        this.state =state;
        this.core = core;
    }

}
