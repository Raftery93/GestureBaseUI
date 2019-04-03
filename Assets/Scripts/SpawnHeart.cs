using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeart : MonoBehaviour
{
    float minSpawnTime = 2f;
    float maxSpawnTime = 4f;

    GameObject spawnObject;
    // Start is called before the first frame update
    void Start () {
        //yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        //Instantiate here
        //Let's spawn our cubes
        //spawnObject.SetActive(true);
        //Instantiate(spawnObject,transform.position,Quaternion.identity);
        spawnObject.transform.position = Random.insideUnitCircle * 5;
    }      

    // Update is called once per frame
    void Update()
    {
        
    }
}
