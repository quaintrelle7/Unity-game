using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed = 4.0f;

    private player _player;
    private Animator _anim;
    private AudioSource _audioSource;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<player>();
        _audioSource = GetComponent<AudioSource>();
        //null check player
    if(_player == null)
        {
            Debug.LogError("PLayer is null");
        }
        _anim = GetComponent<Animator>();
        if(_anim == null)
        {
            Debug.LogError("Animator is null.");
        }
        //assign the component to animator
    }

    // Update is called once per frame
    void Update()
    {
    //move the enemy down at4metres per second
    // if bottom of screen then respawns at the top with new random x position
     transform.Translate(Vector3.down *_speed * Time.deltaTime);

     if(transform.position.y< -20.0f)
     {
      float randomX = Random.Range(-29.2f,2.6f);
      transform.position = new Vector3(randomX,0,0);
	 }  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
     Debug.Log("Hit:  "+ other.transform.name);
     
     //if other is player
     //destroy  the player
     //destroy us
     if(other.tag == "Player")
     {
     //damage player
     player player = other.transform.GetComponent<player>();
     //other.transform.GetComponent<Player>().Damage();
     if(player != null)
     {
      player.Damage();
	 }
      _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
        _audioSource.Play();
      Destroy(this.gameObject,2.3f);
      }
     //if other is laser
     //destroy the laser
     //DESTROY us

     if(other.tag == "Laser")
     {
         _audioSource.Play();
      Destroy(other.gameObject);
            //trigger anim
      
     if(_player != null)
     {
      _player.AddScore(10);
      
	 }
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            
      Destroy(GetComponent.Collider2D);
      Destroy(this.gameObject,2.3f);
      



        }


    }
}
