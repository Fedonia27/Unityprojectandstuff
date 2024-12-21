using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewSpawner : MonoBehaviour
{
    GameObject Meteor;
    public GameObject MeteorPrefab;
    public GameObject MeteorPrefab2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnMeteors", 2.0f, 7.0f);
        InvokeRepeating("spawnMeteors2", 2.0f, 15.0f);


    }

    // Update is called once per frame
    void Update()
    {
        //float randomvelX = Random.Range(-100, 100);
        //float randomvelY = Random.Range(-100, 100);
        //float randomvelZ = Random.Range(-100, 100);
        //Vector3 FunnyVector = new Vector3(randomvelX, randomvelY, randomvelZ);

        //Meteor = Instantiate(MeteorPrefab, new Vector3(randomvelX, randomvelY, randomvelZ), Quaternion.identity);
        //Debug.Log("yo momma")
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
    void spawnMeteors()
    {

        float randomvelX = Random.Range(-100, 100);
        float randomvelY = Random.Range(-100, 100);
        float randomvelZ = Random.Range(-100, 100);
        //Vector3 FunnyVector = new Vector3(randomvelX, randomvelY, randomvelZ);

        Meteor = Instantiate(MeteorPrefab, new Vector3(randomvelX, randomvelY, randomvelZ), Quaternion.identity);
    }
    void spawnMeteors2()
    {

        float randomvelX2 = Random.Range(-100, 100);
        float randomvelY2 = Random.Range(-100, 100);
        float randomvelZ2 = Random.Range(-100, 100);
        //Vector3 FunnyVector = new Vector3(randomvelX, randomvelY, randomvelZ);

        Meteor = Instantiate(MeteorPrefab2, new Vector3(randomvelX2, randomvelY2, randomvelZ2), Quaternion.identity);
    }
}
