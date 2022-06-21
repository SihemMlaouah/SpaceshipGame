using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private Vector3 target;
    public  GameObject Shot;
    public Transform ShotSpawn;
    // Update is called once per frame
    void Update()
    {
        PointandShoot();  
    }

    void PointandShoot()
    {
        target = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(target);
        
            Vector3 direction = new Vector3(target.x  - transform.position.x,0.0f, target.z - transform.position.z);
            transform.up = direction;
        if(Input.GetMouseButtonDown(0))
        {
            GameObject b=Instantiate(Shot, ShotSpawn.position,ShotSpawn.rotation) as GameObject;
            GetComponent<AudioSource>().Play();
            Destroy(b, 2.0f);
        }
    }

   
}
