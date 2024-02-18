using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform target;
    public float cooldown = 5f;
    public float range = 10f;

    private float last;

    void Start()
    {
        last = 0f;
    }

    void Update()
    {
        last += Time.deltaTime;

        // Perform raycast periodically
        if (last >= cooldown)
        {
            last = 0f;
            Shoot();
        }
    }

    void Shoot()
	{
	    if (target != null)
	    {
	        Vector3 direction = (target.position - transform.position).normalized;
	        RaycastHit hit;

	        if (Physics.Raycast(transform.position, direction, out hit, range))
	        {
	            if (hit.transform.CompareTag("Player"))
	            {
	                hit.transform.GetComponent<PlayerScript>().TakeDamage();
	                Debug.Log("Player hit");
	            }
	        }
	    }
	}

}
