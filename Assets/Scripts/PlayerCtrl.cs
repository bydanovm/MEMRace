using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float vInput, hInput;
    private Rigidbody _rb;
    private Vector3 _vc3;
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
                        Time.fixedDeltaTime).x,
                        (this.transform.position + 
                        this.transform.right * vInput * 
                        Time.fixedDeltaTime).y,
                        0f);
        _rb.MovePosition(_vc3);
    }
}
