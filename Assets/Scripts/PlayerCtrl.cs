using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float vInput, hInput;
    private static float hSpeed = 3f;
    private static float vSpeed = 5f;
    private Rigidbody _rb;
    private Vector3 _vc3;

    public delegate void CarWallCollision();
    public event CarWallCollision carWallCollision;
    
    Car playerCar = new Car(hSpeed, vSpeed);
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate() {
        // Обработка движения машинки
            _vc3 = new Vector3((this.transform.position - 
                            this.transform.up * hInput * 
                            hSpeed * Time.fixedDeltaTime).x,
                            (this.transform.position + 
                            this.transform.right * vInput * 
                            vSpeed * Time.fixedDeltaTime).y,
                            0f);
            _rb.MovePosition(_vc3);
    }
    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.name == "Wall"){
            carWallCollision();
        }
    }
}