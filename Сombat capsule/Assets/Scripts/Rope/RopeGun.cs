using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active,
}

public class RopeGun : MonoBehaviour
{
    public Hook hook;
    public Transform spawn;
    public float speed;
    public SpringJoint springJoint;
    public Transform ropeStart;

    public RopeState currentRopeState = RopeState.Disabled;
    public RopeRenderer ropeRenderer;
    public PlayerMove playerMove;

    private float _length;

    private void Start()
    {
        ropeRenderer.Hide();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shot();
        }

        if (currentRopeState == RopeState.Disabled)
        {
            ropeRenderer.Hide();
        }

        if (currentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(ropeStart.position, hook.transform.position);
            if (distance > 20)
            {
                hook.gameObject.SetActive(false);
                currentRopeState = RopeState.Disabled;
                ropeRenderer.Hide();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentRopeState == RopeState.Active)
            {
                if (playerMove.isGrounded == false)
                {
                    playerMove.JumpForce();
                }
            }

            DestroySpring();
        }

        if (currentRopeState == RopeState.Active || currentRopeState == RopeState.Fly)
        {
            ropeRenderer.Draw(ropeStart.position, hook.transform.position, _length);
        }
    }

    private void Shot()
    {
        currentRopeState = RopeState.Fly;
        _length = 1;

        if (springJoint)
        {
            Destroy(springJoint);
        }

        hook.gameObject.SetActive(true);

        hook.StopFix();

        hook.transform.position = spawn.position;
        hook.transform.rotation = spawn.rotation;
        hook.hookRigidbody.velocity = spawn.forward * speed * Time.unscaledDeltaTime;
    }

    public void CreateSpring()
    {
        if (springJoint == null)
        {
            currentRopeState = RopeState.Active;

            springJoint = gameObject.AddComponent<SpringJoint>();
            springJoint.connectedBody = hook.hookRigidbody;
            springJoint.anchor = ropeStart.localPosition;
            springJoint.autoConfigureConnectedAnchor = false;
            springJoint.connectedAnchor = Vector3.zero;
            springJoint.spring = 100;
            springJoint.damper = 5;

            _length = Vector3.Distance(ropeStart.position, hook.transform.position);
            springJoint.maxDistance = _length;
        }
    }

    public void DestroySpring()
    {
        if (springJoint)
        {
            currentRopeState = RopeState.Disabled;
            hook.gameObject.SetActive(false);
            Destroy(springJoint);
            ropeRenderer.Hide();
        }
    }
}