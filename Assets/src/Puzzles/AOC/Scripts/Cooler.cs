using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Cooler : Game{
    
    Vector3 posicInicial;
    Vector3 posicFinal;
    Vector3 vetorDirecao;
    Rigidbody2D _rigidbody2D;
    bool estaArrastando;
    float distancia;

    [HideInInspector]
    public bool estaConectado;

    [Range(1,15)]
    public float velocidadeDeMovimento = 3;

    public Transform conector;

    [Range(0.1f,2.0f)]
    public float distanciaMinimaConector = 0.5f;

    void Start(){
        _rigidbody2D = transform.root.GetComponent<Rigidbody2D>();
        _rigidbody2D.GetComponent<Rigidbody2D>().isKinematic = true;
        _rigidbody2D.gravityScale = 0;
    }

    void OnMouseDown(){
        posicInicial = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        estaArrastando = true;
        estaConectado = false;
    }

    void OnMouseDrag(){
        posicFinal = posicInicial + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = posicFinal;
    }

    void OnMouseUp(){
        estaArrastando = false;
    }

   void FixedUpdate(){
        distancia = Vector2.Distance(transform.root.position, conector.position);
        if(distancia < distanciaMinimaConector){
            transform.root.position = Vector2.MoveTowards(transform.root.position,conector.position,0.02f);
        }
        if(distancia < 2){
            estaConectado = true;
            _rigidbody2D.gravityScale = 1;
            transform.root.position = conector.position;
        }
    }
}
