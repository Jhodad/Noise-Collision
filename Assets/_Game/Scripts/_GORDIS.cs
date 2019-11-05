using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GORDIS : MonoBehaviour
{

    private Vector3 horiz;
    private Vector3 verti;

    bool popo;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * Time.deltaTime;
        horiz = new Vector3(x, 0, 0);
        verti = new Vector3(0, 0, z);

        if(x > 0)
        {
            //si si se cumple
            transform.Translate(horiz * 12, Space.World);
            
        }
        else
        {
            // si no
            
            transform.Translate(horiz * 12, Space.World);
        }

        if (x == 0){
            Debug.Log("Baka, no me estoy moviendo");
        }

        if (Input.GetKey(KeyCode.B ))
        {
            Debug.Log("Baka");
        }

        transform.Translate(verti * 12, Space.World);





        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }
                



        

    }
}
