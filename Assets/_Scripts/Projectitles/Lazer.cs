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
    private float damageRadius;
    [SerializeField]
    private bool isGravityOn;
    private bool hasHitGround;

    [SerializeField]
    private LayerMask whatisGround;
    [SerializeField]
    private LayerMask whatisPlayer;
    [SerializeField]
    private BoxCollider2D BoxColliderMega;

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

    /*        if (isGravityOn)
            {
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }*/
        }
    }
    private void FixedUpdate()
    {
        if (!hasHitGround)
        {
            Collider2D damageHit = Physics2D.OverlapCircle(BoxColliderMega.size, damageRadius, whatisPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(BoxColliderMega.size, damageRadius, whatisGround);

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
            if (groundHit)
            {
                hasHitGround = true;
                /*rb.gravityScale = 0f;
                rb.velocity = Vector2.zero;*/
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
        Gizmos.DrawWireSphere(BoxColliderMega.size, damageRadius);
    }
}
