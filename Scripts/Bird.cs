using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable All

public class Bird : MonoBehaviour
{
    private float upForce = 200f;
    private float speed = 5;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private AudioSource flapSound;

    // Start is called before the first frame update
    void Start()
    {

        //get bird component rigid body.
        rb2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        flapSound = GetComponent<AudioSource>();


        /*Debug.Log("deneme");*/
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false) //ölmediyse
        {
            if (Input.GetMouseButtonDown(0)) //her mouse tıklamada
            {
                //bird rigidbody öncek tıklamadan kalan hızı sıfırla
                //sıfırlamazsak birkaç tıklamadan sonra hız katlanarak artacak ve bird sahne dışına taşacak
                rb2d.velocity = Vector2.zero;
                
                //bird rigidbody - yukarıya doğru (y ekseni) upForce kadar kuvvet uygula 
                rb2d.AddForce(new Vector2(0, upForce));
                
                anim.SetTrigger("Flap");
                
                flapSound.Play();
                
                
            }
        }
        
    }

    //BIRD collisona sahip başka bir nesne ile çarpıştığında çağrılır.
    //UNITY API'ye ait bir fonksiyondur.
    private void OnCollisionEnter2D(Collision2D other)
    {
        //çarpışma anında bird ölür
        GameControl.instance.BirdDead();
        isDead = true;
        anim.SetTrigger("Die");
        
        
        
    }
    
        
    
}