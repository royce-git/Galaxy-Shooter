using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField]
    private float _speed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //move up at some speed
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        //if position of the laser on the y > 6 then destroy the laser

       if (transform.position.y > 6)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            //destroy laser
            Destroy(this.gameObject);

        }
            
    
        
	}
}
