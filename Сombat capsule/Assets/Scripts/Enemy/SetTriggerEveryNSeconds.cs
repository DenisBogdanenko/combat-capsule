using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    public Animator animator;
    public float period = 7;
    public string triggerName = "Attack";

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > period)
        {
            _timer = 0;
            animator.SetTrigger(triggerName);
        }
    }
}
