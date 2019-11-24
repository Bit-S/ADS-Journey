using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : PlayerController
{
    public Transform matDiscPortal;
    public Transform redesPortal;
    public Transform aocPortal;
    public Transform bdPortal;
    public Transform estDadosPortal;
    public Transform algoritmoPortal;
    public Transform gpPortal;
    public Transform engPortal;
    public Transform soPortal;

    new void Start() {
        base.Start();
        m_CapsulleCollider  = GetComponent<CapsuleCollider2D>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    new void Update()
    {
        CheckInput(Interact);
        if(transform.position.y < -20.2f) transform.position = new Vector3(transform.position.x, 10, 90);
        if(transform.position.y < -20.15f) LoadScene("BonusPersistent");   
    }

    void Interact(){
        if(Near(matDiscPortal)) StartCoroutine(GoToPuzzle("MatDiscIntro", matDiscPortal));
        if(Near(redesPortal)) StartCoroutine(GoToPuzzle("RedesIntro1", redesPortal));
        if(Near(aocPortal)) StartCoroutine(GoToPuzzle("AOCintro", aocPortal));
        if(Near(algoritmoPortal)) StartCoroutine(GoToPuzzle("AlgoritmoIntro", algoritmoPortal));
        if(Near(estDadosPortal)) StartCoroutine(GoToPuzzle("estDadosIntro", estDadosPortal));
        if(Near(bdPortal)) StartCoroutine(GoToPuzzle("BDintro", bdPortal));
        if(Near(gpPortal)) StartCoroutine(GoToPuzzle("GestaoProjetosIntro", gpPortal));
        if(Near(engPortal)) StartCoroutine(GoToPuzzle("EngIntro", engPortal));
        if(Near(soPortal)) StartCoroutine(GoToPuzzle("SOintro", soPortal));
    }

    IEnumerator GoToPuzzle(string puzzle, Transform portal){
        Camera.main.GetComponent<CameraMove>().enabled = false;
        for(byte i = 0; i < 15; i++){
            transform.localScale *= 0.95f;
            transform.Rotate(0,0,20, Space.World);
            transform.position = portal.transform.position - new Vector3(0,0,4);
            yield return new WaitForSeconds(0.08f);
        }
        LoadScene(puzzle);
    }
}
