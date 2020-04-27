using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable All

public class RepeatingBackground : MonoBehaviour
{
    
    private BoxCollider2D groundCollider;//Ground üzerinde tanımlı olan collider
    private float groundHorizontalLength;//Ground gameobjectin x ekseni üzerindeki uzunluk bilgisi
    
    // Start is called before the first frame update
    void Awake()
    {
        //Get and store a reference to the collider2D attached to Ground.
        groundCollider = GetComponent<BoxCollider2D> ();
        //Store the size of the collider along the x axis (its length in units).
        groundHorizontalLength = groundCollider.size.x;
        
    }

    // Update is called once per frame
    void Update()
    {
    
        //Debug.Log(groundHorizontalLength);
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground ();
        }
    }
    
    //Arkaplanı bir döngü olarak sürekli ileriye taşır.
    private void RepositionBackground()
    {
        //arkaplanı ne kadar sağa kaydıracağımızı (offset) belirliyoruz
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

        //ground mevcut pozisyonunu + offset kadar sağa taşıyoruz.
        transform.position = (Vector2) transform.position + groundOffSet;
    }
}
