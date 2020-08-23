using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 7.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _firerate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
   private GameObject _tripleShotPrefab;

    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    

   [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private bool _isSpeedBoosterActive = false;
    [SerializeField]
    private float _speedMultiplier = 2.0f;
    [SerializeField]
    private bool _isShieldActive = false;
    [SerializeField]
    private GameObject _shieldVisualizer;
    [SerializeField]
    private GameObject _rightEngine;
    [SerializeField]
    private GameObject _leftEngine;
    [SerializeField]
    private int _score;

    private UIManager _uiManager;
    
    [SerializeField]
    private AudioClip _laserSoundClip;
    [SerializeField]
    private AudioSource _audioSource;

  
    void Start()
    {
      transform.position = new Vector3(1f, -20f, 0);
    
      _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
      _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
      _audioSource = GetComponent<AudioSource>();
      if(_spawnManager ==  null)
      {
       Debug.LogError("The spawn manager is null");
	  }

      if(_uiManager == null)
      {
       Debug.LogError("The UIManager is null");
	  }
    if(_audioSource == null)
    {
      Debug.LogError("AudioSource is null");
    }
    else
    {
     _audioSource.clip = _laserSoundClip;

    }
    }

    // Update is called once per frame
    void Update()
    {   
     CalculateMovement();

     //if i hit the space key
     //spawn the object

     if(Input.GetKeyDown(KeyCode.Space))
     {
     // Debug.Log("Space Key Pressed"); ISKA MEANING NHI PATA
     FireLaser();

     //if tripleShotActive is true then fire 
     //three lasers else fire the one laser only

	 }
	   }

       void CalculateMovement()
       {
       float verticalInput = Input.GetAxis("Vertical");
        float horizonatalInput = Input.GetAxis("Horizontal");

        
       
       transform.Translate(new Vector3(horizonatalInput, verticalInput,0)*_speed* Time.deltaTime);

       /*if(transform.position.y>=0)
       {
        transform.position = new Vector3(transform.position.x,0,0);
	   }
       else if(transform.position.y<= -24.5f)
       {
        transform.position = new Vector3(transform.position.x, -24.5f, 0);*/

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -20.08f,0), 0);
        if(transform.position.x>=7.8f)
        {
        transform.position = new Vector3(-34.8f, transform.position.y, 0);
		}
        else if(transform.position.x<-34.8f)
        {
        transform.position = new Vector3(7.8f, transform.position.y,0);  
		}
       }

       void FireLaser()
       {
       _canFire = Time.time + _firerate;
       

        if(_isTripleShotActive == true)
     {
     //Instantiate for triple shot
     Instantiate(_tripleShotPrefab, transform.position + new Vector3(0, 23f,0), Quaternion.identity);
	 }
     else{
     Instantiate(_laserPrefab, transform.position + new Vector3(0, 4.3f, 0), Quaternion.identity);

	 }

   //play the audio clip

      _audioSource.Play();

	   }

       public void Damage()
       {
       if( _isShieldActive == true)
       {
        _shieldVisualizer.SetActive(false);
            _isShieldActive = false;
        return;
       }
     
       _lives --;

       if(_lives == 2)
       {
         _leftEngine.SetActive(true);
       }
       else if (_lives == 1)
       {
         _rightEngine.SetActive(true);
       }
	   
       _uiManager.UpdateLives(_lives);

       if(_lives<1)
       {
       //when player dies let them know to the  spawn manager that the player is dead.
        //find the GameObject and then get the component
        _spawnManager.OnPlayerDeath();
        Destroy(this.gameObject);

       }

	   }
    
       public void TripleShotActive()
       {
        //tripleshotactive becomes true
        //start the powerdown coroutine for TripleShot
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
	   }

       //IEnumerator TripleShotPowerDownCoroutine
       //wait 5 secs
       //set the triple shot to false
       IEnumerator TripleShotPowerDownRoutine()
       {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;

	   }

       public void SpeedBoosterActive()
       {
         
        _isSpeedBoosterActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostPowerDownRoutine());
	   }
       
       IEnumerator SpeedBoostPowerDownRoutine()
       {
             yield return new WaitForSeconds (5.0f);
        _isSpeedBoosterActive = false;
        _speed /=  _speedMultiplier;
   
	   }

       public void ShieldIsActive()
       {
       _isShieldActive = true;
       _shieldVisualizer.SetActive(true);
       
       }
       
       public void AddScore(int points)
       {
        _score += points;
        _uiManager.UpdateScore(_score);
	   }

       

       
    }


