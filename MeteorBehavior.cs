using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{
    Rigidbody rb;
    public float minX, minY, maxX, maxY, minZ, maxZ;
    public AudioSource ExploSound;


    // Start is called before the first frame update
    void Start()
    {
        float randomvelX = Random.Range(-10, 10);
        float randomvelY = Random.Range(-10, 10);
        float randomvelZ = Random.Range(-10, 10);
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(randomvelX, randomvelY, randomvelZ), ForceMode.Impulse);
        rb.AddTorque(new Vector3(randomvelX, randomvelY, randomvelZ), ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        if (transform.position.x < minX) newPos.x = -minX;
        if (transform.position.x > maxX) newPos.x = -maxX;
        if (transform.position.y > maxY) newPos.y = -maxY;
        if (transform.position.y < minY) newPos.y = -minY;
        if (transform.position.z < minZ) newPos.z = -minZ;
        if (transform.position.z > maxZ) newPos.z = -maxZ;

        transform.position = newPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        ExploSound.Play();
        Destroy(other.gameObject);
        Destroy(this.gameObject);

    }
}
