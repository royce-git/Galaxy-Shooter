using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool gameOver = true;
    public GameObject player;

    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    //if gameOver is true
    //if spacekey pressed
    //spawn player
    //gameOver is false
    //hide title screen

    private void Update()
    {
        if(gameOver == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
                gameOver = false;
                _uiManager.HideTitleScreen();
            }
        }
    }
}
