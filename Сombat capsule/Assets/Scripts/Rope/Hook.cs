using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Rigidbody hookRigidbody;
    public Collider hookCollider;
    public Collider playerCollider;
    public RopeGun ropeGun;

    private FixedJoint _fixedJoint;

    private void Start()
    {
        Physics.IgnoreCollision(hookCollider, playerCollider);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();

            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            ropeGun.CreateSpring();
        }
    }

    public void StopFix()
    {
        if (_fixedJoint)
        {
            Destroy(_fixedJoint);
        }
    }
}
