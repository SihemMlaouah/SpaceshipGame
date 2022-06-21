using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float maxX, minX, maxZ, minZ;
}
public class PlayerShipController : MonoBehaviour
{
    public float speed = 10.0f;
    public float tilt;
    public Boundary boundary;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody>();
       
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0.0f, vertical);
        rigidbody.velocity = move*speed;
        rigidbody.position = new Vector3(Mathf.Clamp(rigidbody.position.x,boundary.minX,boundary.maxX), 0.0f, Mathf.Clamp(rigidbody.position.z,boundary.minZ,boundary.maxZ));
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);

        

    }

    public void ChangeJumps()
    {
         ScoringandHealthSystem.Jumps-=1;
         if (ScoringandHealthSystem.Jumps == 0)
         {
          FindObjectOfType<GameManager>().EndGame();
         }
         else
         {
         Vector3 safePlace = new Vector3(0,0,0);
         this.gameObject.transform.position = safePlace;
         }
            
    } 
        
    

    
}
