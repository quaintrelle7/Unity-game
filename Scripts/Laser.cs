using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 11.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.up* _speed * Time.deltaTime); 
       //destroy the object
       if(transform.position.y >8f)
       {
       //check if this object has a parent too
       //if does then destroy the parent too.
       if(transform.parent != null)
       {
        Destroy(this.transform.parent.gameObject);
	   }
        Destroy(this.gameObject);
	   }

    }
}

