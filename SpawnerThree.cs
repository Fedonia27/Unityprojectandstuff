using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerThree : MonoBehaviour
{
    GameObject Meteor;
    public GameObject MeteorPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnMeteors", 2.0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        float randomvelX = Random.Range(-100, 100);
        float randomvelY = Random.Range(-100, 100);
        float randomvelZ = Random.Range(-100, 100);

        //Meteor = Instantiate(MeteorPrefab, new Vector3(randomvelX, randomvelY, randomvelZ));
    }
}
