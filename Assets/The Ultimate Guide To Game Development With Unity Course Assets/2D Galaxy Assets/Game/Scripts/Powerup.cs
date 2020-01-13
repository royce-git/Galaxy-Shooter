using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID; //0= trippleshot, 1= speed boost, 2= shield

    [SerializeField]
    private AudioClip _clip;

	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);


            if (player != null)
            {
                if (powerupID == 0)
                {
                    player.TripleShotPowerupOn();
                }
                else if (powerupID == 1)
                {
                    player.SpeedBoostPowerupOn();

                }
                else if (powerupID == 2)
                {
                    player.EnableShields();
                }

            }


            Destroy(this.gameObject);
        }
        
    }
}
