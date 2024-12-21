using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    GameObject BigBullet;
    public float bullSpeed;
    public GameObject Spaceship;
    Rigidbody rb;
    public AudioSource Sounder;
    public GameObject ExplosionEffect;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Sounder.Play();
            Instantiate(ExplosionEffect);
            Vector3 offset = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
            BigBullet = Instantiate(projectilePrefab, transform.position, Spaceship.transform.rotation);
            rb = BigBullet.GetComponent<Rigidbody>();
            //BigBullet.GetComponent<Rigidbody>().velocity = Spaceship.GetComponent<Rigidbody>().velocity + Vector3.forward * bullSpeed;
            rb.AddRelativeForce(new Vector3(0, 1 + bullSpeed, 0) );

        }
    }
}
