using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{

    private AttackDetail attackDetails;
    protected D_RangeAttaclState stateData;

    private float speed;
    private float travelDistance;
    private float xStartPos;
    [SerializeField]
    private bool isGravityOn;
    private bool hasHitGround;

    [SerializeField]
    private LayerMask whatisGround;
    [SerializeField]
    private LayerMask whatisPlayer;
    [SerializeField]
    private BoxCollider2D BoxColliderMega;
    [SerializeField]
    private Transform damagePosition;

    private void Start()
    {
        BoxColliderMega = GetComponent<BoxCollider2D>();
  
        isGravityOn = false;

        xStartPos = transform.position.x;
    }

    private void Update()
    {
        if (!hasHitGround)
        {
            attackDetails.position = transform.position;
            transform.position = BoxColliderMega.size;
        }
    }
    private void FixedUpdate()
    {
        if (!hasHitGround)
        {
            Collider2D damageHit = Physics2D.OverlapBox(damagePosition.position, BoxColliderMega.size, whatisPlayer);

            if (damageHit)
            {
                IDamageable damageable = damageHit.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.Damage(attackDetails.damageAmount);
                }
                Debug.Log("Attack +1");
                Destroy(gameObject);
            }
            //f cham abs gia tri tuyet doi vi tri bat dau - bien doi vi tri cham x l
            if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance && !isGravityOn)
            {
                isGravityOn = true;
                /*rb.gravityScale = gravity;*/
            }
        }
    }

    public void FireProjectile(float speed, float travelDistance, float damage)
    {

        this.speed = speed;
        this.travelDistance = travelDistance;
        attackDetails.damageAmount = damage;
        Debug.Log("damage 1" + damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(damagePosition.position, BoxColliderMega.size);
    }
}
