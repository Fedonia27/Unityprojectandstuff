using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBulletCont : MonoBehaviour
{
    public float timeLeft = 10;
    public float minX, minY, maxX, maxY, minZ, maxZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 )
        {
            Destroy(this.gameObject);

        }
        Vector3 newPos = transform.position;
        if (transform.position.x < minX) newPos.x = -minX;
        if (transform.position.x > maxX) newPos.x = -maxX;
        if (transform.position.y > maxY) newPos.y = -maxY;
        if (transform.position.y < minY) newPos.y = -minY;
        if (transform.position.z < minZ) newPos.z = -minZ;
        if (transform.position.z > maxZ) newPos.z = -maxZ;

        transform.position = newPos;
    }
}
