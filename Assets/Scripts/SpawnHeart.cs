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
        // randomTime = 95; // For testing.
        Debug.Log("RandomTime: " + randomTime);
       
    }      

    // Update is called once per frame
    void Update()
    {
       
        timer -= Time.deltaTime;

        if(randomTime == (int)timer && isSpawned == 1){
            isSpawned = 0;
            SpawnHeartPos();
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
        Vector2 pos = center + new Vector2((RandomNumber(-4,6)), 3);
        
            Instantiate(spawnObject, pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center, size);
    }
}
