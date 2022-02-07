using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float _timer;

    public AudioSource shotSound;
    public GameObject bulletPrefab;
    public Transform spawn;
    public float bulletSpeed = 10;
    public float shotPeriod = 0.2f;


    void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if (_timer > shotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0;
                Shot();
            }
        }
    }

    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, spawn.position, spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = spawn.forward * bulletSpeed * Time.unscaledDeltaTime;
        shotSound.Play();
        shotSound.pitch = Random.Range(0.8f, 1.2f);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numberOfBulletsToAdd)
    {

    }
}
