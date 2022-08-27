using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CarsMove : MonoBehaviour
{
    private float speed = 3f;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        _rb.MovePosition(this.transform.position + 
                        this.transform.right * speed * 
                        Time.fixedDeltaTime);
        if(this.transform.position.y < -15f)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }
    }
}
