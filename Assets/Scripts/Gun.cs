using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10.0f;
    //public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 10f;

    public ParticleSystem flash;
    public GameObject impact;
    public Camera fpsCam;

    private float nextTimeToFIre = 0f;
    
    void Update()
    {

    }

    public void ShootTrigger()
    {
        if (Time.time >= nextTimeToFIre)
        {
            nextTimeToFIre = Time.time + 1f / fireRate; // if firerate is 4 it means that we can shoot every 0.25 seconds
            Shoot();
        }
    }
    void Shoot()
    {
        flash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)) //Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,range) to define the range
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target!=null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody!=null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactObject =Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObject, 2f);
        }
    }
}
