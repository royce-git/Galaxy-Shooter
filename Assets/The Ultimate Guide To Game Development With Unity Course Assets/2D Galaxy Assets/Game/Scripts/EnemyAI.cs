using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    //enemy Explosion
    [SerializeField]
    private GameObject _enemyExplosionsPrefab;

    //speed variable
    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private AudioClip _clip;

    private UIManager _uiManager;

	// Use this for initialization
	void Start ()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
        //move down
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y < -7)
        {
            //when off the screen on the bottom
            //respawn on top with a new x position within the bounds of the screen
            float randomX = Random.Range(-7f, 7f);
            transform.position = new Vector3(randomX, 7, 0);
        }
        

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            if(other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }

            Destroy(other.gameObject);
            Instantiate(_enemyExplosionsPrefab, transform.position, Quaternion.identity);
            _uiManager.UpdateScore();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }
            Instantiate(_enemyExplosionsPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
    }
}
