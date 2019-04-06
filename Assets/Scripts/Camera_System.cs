using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Camera_System : MonoBehaviour
{

    public GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player); // Find the object to clamp the camera to.
    }

   
  
    // Update is called once per frame
    void LateUpdate()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z); // So the camera follows the player object.
    }
}
