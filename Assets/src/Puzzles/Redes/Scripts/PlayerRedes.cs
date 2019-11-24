using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerRedes : PlayerController
{

    public static bool reachedServer = false;

    new void Start()
    {
        base.Start();
        m_CapsulleCollider  = this.transform.GetComponent<CapsuleCollider2D>();
        m_rigidbody = this.transform.GetComponent<Rigidbody2D>();
        reachedServer = false;
    }


    new void Update()
    {
        base.Update();
        CheckInput(PerformJump);

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Wall") {
            if(reachedServer) transform.position = GameObject.Find("Server").transform.position;
            else transform.position = new Vector3(-5,0.2f,0);
            Redes.time = 16;
        }
        if(other.name == "Server") {
            reachedServer = true;
            Destroy(GameObject.Find("PackRequest"));
            Redes.time = 16;
        }
        if(other.name == "Intermediario"){
            Redes.time = 11;
        }
        if(other.name == "PC"){
            if(reachedServer){
                StartCoroutine(new Redes().HandleVictory());
            }
        }
    }

}
