using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeart : MonoBehaviour
{

    public Vector2 center;

    public float randomTime;
    public float timer = 100f;
    
    public Vector2 size;
    public GameObject spawnObject;
    public Transform spawnPoint;
    private float heartWidth = 1f;

    public int isSpawned = 1;
    // Start is called before the first frame update
    void Start () {

        randomTime = RandomNumber(10, 80);
        //randomTime = 95;
        //SpawnHeartPos();
        Debug.Log("RandomTime: " + randomTime);
        //Get object for platform
        //heartWidth = spawnObject.GetComponent<BoxCollider2D>().size.y;

        //spawnObject.transform.position = Random.insideUnitCircle * 5;
    }      

    // Update is called once per frame
    void Update()
    {
         //Get random x value between boundaries
        //int randomXPos = RandomNumber(-4, 6);



        timer -= Time.deltaTime;

        //Debug.Log("RandomTime: " + randomTime + " Timer: " + timer);

        if(randomTime == (int)timer && isSpawned == 1){
            isSpawned = 0;
            Debug.Log("SPAWN!!!!!!");
            SpawnHeartPos();
        }
        //If Random time
        //if (true)
        //{
            //Create switch statement for 3 platform positions
            //Create 1 or 2 platforms (Random)

            //Change position on x axis (Random number)
         //   transform.position = new Vector2(randomXPos, 0);

            //Create platforms
         //   Instantiate(spawnObject, transform.position, transform.rotation);

       // }
        //Destroy heart after 5 sec
       // Destroy(spawnObject, 5);
        
    }

    // Generate a random number between two numbers
    public int RandomNumber(int min, int max)
    {
        System.Random ran = new System.Random();
        int number = ran.Next(min, max);
        return number;
    }

    public void SpawnHeartPos(){
        Vector2 pos = center + new Vector2((RandomNumber(-4,6)), 3);
        
            Instantiate(spawnObject, pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center, size);
    }
}
