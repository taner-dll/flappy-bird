using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    
    public int columnPoolSize = 5; //How many columns to keep on standby.
    public GameObject columnPrefab; //The column game object.
    public float spawnRate = 4f;//How quickly columns spawn.
    public float columnMin = -1f;//Minimum y value of the column position.
    public float columnMax = 3.5f; //Maximum y value of the column position.
    
    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f; //üretilecek sütunların yatay pozisyonları sabit aralıkta olmalı.
    private int currentColumn = 0;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        //Initialize the columns collection.
        //belirtilen adet kadar column game object oluştur.
        columns = new GameObject[columnPoolSize];

        //...and create the individual columns.
        for (int i = 0; i < columnPoolSize; i++)
        {
            //her birinin örneğini oluştur.
            columns[i] = (GameObject) Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // oyun bitmediği sürece sütun oluşturacağız.
    void Update()
    {

        //her update süresini doğum süresi olarak tutuyoruz.
        //delta time olarak tutalım ki süre kayıplarını kendi ayarlasın
        timeSinceLastSpawned += Time.deltaTime;

        //game konroldeki gameover durumu false değilse (oyun devam ediyorsa)
        //ve spawnRate (4 sn) geçmişse... 
        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            //sayacı sıfırla
            timeSinceLastSpawned = 0;

            //kolon dikey konumumunu min-max aralığında rastgele belirle.
            float spawnYPosition = Random.Range(columnMin, columnMax);
            
            //...then set the current column to that position.
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            
            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
            


        }
        


    }
}