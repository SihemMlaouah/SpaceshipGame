using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroids : MonoBehaviour
{
    
    Rigidbody rb;
    public GameObject explosion;
    public GameObject PlayerExplosion; 
    public float tumble = 5;
    public float speed = -20.0f;
    int asteroidCounter=100;
    public float invincibleTimer;
    public float timeInvincible = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        rb.angularVelocity = Random.insideUnitSphere*tumble;
       
        invincibleTimer = 0;

   
    }


    

    void OnTriggerEnter(Collider other)
    { 
      
        GameObject e=Instantiate(explosion, transform.position, transform.rotation) as GameObject;
       PlayerShipController player = other.gameObject.GetComponent<PlayerShipController>();
        Destroy(e, 2.0f);
        if (other.tag == "Player")
        {
            /*if (invincibleTimer == timeInvincible)
            { 
                invincibleTimer =Time.deltaTime;
                Debug.Log("here");
            }
            else if(invincibleTimer==0)
            {*/
                Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
                
                player.ChangeJumps();
           /* }*/ // invincibility didn't work ...

        }
        else
        {
            /*if (this.tag == "Red")
            {
                
               
                invincibleTimer = timeInvincible;
            }*/
            ScoringandHealthSystem.score += 10;
            Destroy(other.gameObject);
            

        }

    Destroy(gameObject);
    asteroidCounter--;
        
        if(ScoringandHealthSystem.score==asteroidCounter*10)
        {
            SceneManager.LoadScene("Winner");
        }
     
    } 
}

