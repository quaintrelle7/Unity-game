using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int powerupID; //TripleShot = 0, Speed = 1, Shield = 2
    [SerializeField]
    private AudioClip _clip;
    

    // Update is called once per frame
    void Update()
    {
     // move down with speed 3
     //when we leave the screen , destroy this object
       transform.Translate(Vector3.down* _speed * Time.deltaTime);
        
        if(transform.position.y <-19.2f)
        {
         Destroy(this.gameObject);  
		}

    }
    //on trigger collision
    //Only be collected by the players (Hint: use tags)
    //on collected destroy

    private void OnTriggerEnter2D(Collider2D other)
    {
     if(other.tag == "Player")
     {
     //communicate with player script
      player player = other.transform.GetComponent<player>();
      AudioSource.PlayClipAtPoint(_clip, transform.position);
      
      if(player != null)
      {
       switch(powerupID)
       {
       case 0:
            player.TripleShotActive();
            break;
       case 1:
            player.SpeedBoosterActive();
            break;

       case 2:
            player.ShieldIsActive();
            break;
       default:
            Debug.Log("Default Value");
             break;
       }
	 
       }

      Destroy(this.gameObject);
	 }
	}
}

