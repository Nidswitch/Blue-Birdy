using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class Gun : MonoBehaviour
{
	private float timeBtwAttack;
	public float startTimeBtwAttack = 0.3f;
	public Transform firePoint;
	public GameObject bulletPrefab;
	[SerializeField] private Playercontroller playerController;

    private void Awake()
    {
        if (playerController == null)
        {
            playerController = GetComponentInParent<Playercontroller>();
        }
    }
	private void Update()
    {
        if (playerController != null && !playerController.canShoot) return;

        if (timeBtwAttack <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Shoot();
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

	private void Shoot()
	{
		Instantiate<GameObject>(bulletPrefab, firePoint.position, firePoint.rotation);
	}

	
}
