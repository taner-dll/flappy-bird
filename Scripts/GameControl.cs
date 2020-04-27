using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    //instance dışarıdan kolayca erişilebilmesi için static olarak tanımlandı.
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    public int score = 0;
    public Text scoreText;
    

    // Awake start fonksiyonundan önce çağrılır.
    void Awake()
    {
        
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if(instance != this)
            //...destroy this one because it is a duplicate.
            Destroy (gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the game is over and the player has pressed left click. restart game
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }

        score++;
        scoreText.text = "Skor: " + score.ToString();
    }
    
    public void BirdDead()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }
}
