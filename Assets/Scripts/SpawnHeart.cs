using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeart : MonoBehaviour // Class to control the Heart object.
{

    public Vector2 center; // The center point of where the heart can spawn from.

    public float randomTime; // To generate a random time for the heart to spawn.
    public float timer = 100f; // Initialize a timer to 100.
    
    public Vector2 size;
    public GameObject spawnObject; // The object to be spawned.
    public Transform spawnPoint;
    private float heartWidth = 1f;

    public int isSpawned = 1; // A flag to ensure only 1 heart is spawned per level.

    // Start is called before the first frame update
    void Start () {

        randomTime = RandomNumber(10, 80); // Get a random time.
        //randomTime = 95;
        Debug.Log("RandomTime: " + randomTime);
       
    }      

    // Update is called once per frame
    void Update()
    {
       
        timer -= Time.deltaTime; // Decrement the timer.

        if(randomTime == (int)timer && isSpawned == 1){ // If the timer is equal to the random time, and the heart has not been spawned.
            isSpawned = 0; // Set the flag to 0 to ensure it will not be spawned again in this level.
            SpawnHeartPos(); // Spawn the heart.
        }
      
    }

    // Generate a random number between two numbers
    public int RandomNumber(int min, int max)
    {
        System.Random ran = new System.Random();
        int number = ran.Next(min, max);
        return number;
    }

    public void SpawnHeartPos(){
        Vector2 pos = center + new Vector2((RandomNumber(-4,6)), 3); // Generate a random point to spawn the heart.
        
        Instantiate(spawnObject, pos, Quaternion.identity); // Spawn the heart.
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center, size);
    }
}
