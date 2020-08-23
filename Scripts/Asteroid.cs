using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField]
    private float _rotateSpeed = 5.0f;
    [SerializeField]
    private GameObject _explosionPrefab;
    private SpawnManager _spawnmanager;
    // Start is called before the first frame update
   public void Start()
    {
        _spawnmanager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
           Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
           Destroy(other.gameObject);
           _spawnmanager.StartSpawning();
           Destroy(this.gameObject, 0.5f);
        }
    }
}
