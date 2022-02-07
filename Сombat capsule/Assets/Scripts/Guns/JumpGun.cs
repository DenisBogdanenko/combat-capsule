using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public Rigidbody playerGigidbody;
    public float speed = 12;
    public Transform spawn;
    public Gun pistol;
    public float maxCharge = 3;
    public ChargeIcon chargeIcon;
    public AudioSource shotSound;

    private float _currentCharge;
    private bool _isCharged = true;

    private void Start()
    {
        chargeIcon.SetChargeValue(_currentCharge, maxCharge);
        chargeIcon.StopCharge();
    }

    void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerGigidbody.AddForce(-spawn.forward * speed, ForceMode.VelocityChange);
                pistol.Shot();
                shotSound.Play();
                _isCharged = false;
                _currentCharge = 0;
                chargeIcon.StartCharge();
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            chargeIcon.SetChargeValue(_currentCharge, maxCharge);

            if (_currentCharge >= maxCharge)
            {
                _isCharged = true;
                chargeIcon.StopCharge();
            }
        }
    }
}
