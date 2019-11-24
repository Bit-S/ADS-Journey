using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAlgoritmo : PlayerController
{
    Algoritmo algoritmo;

    public Transform bike;
    public Transform door;
    public Transform building;
    public Transform guarda;
    public Transform rightBuilding;
    public Transform wrongBuilding;
    public Transform tree;

    public GameObject card;

    bool bikeInteract = false;

    bool bikeInteracted = false;
    bool doorInteracted = false;
    bool guardaInteracted = false;
    bool treeInteracted = false;

    bool canMove = true;

    new void Start() {
        base.Start();
        algoritmo = GameObject.Find("Algoritmo").GetComponent<Algoritmo>();
        m_CapsulleCollider  = GetComponent<CapsuleCollider2D>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    new void Update() {
        base.Update();
        if(bikeInteract == false && canMove) 
            CheckInput(Interact);

        HandleBikeInteraction();
        
    }

    void Interact(){
        if(Near(bike)) bikeInteract = true;
        if(Near(door)) HandleDoorInteraction();
        if(Near(guarda)) StartCoroutine(HandleGuardaInteration());
        if(Near(tree)) HandleTreeInteraction();
        if(Near(wrongBuilding)) HandleWrongBuildingInteraction();
        if(Near(rightBuilding)) HandleRightBuildingInteraction();
    }

    void HandleBikeInteraction(){
        if(bikeInteract && transform.position.x < 28) {
            bike.position += new Vector3(0.15f, 0, 0);
            this.transform.position += new Vector3(0.15f, 0, 0);
            bikeInteracted = true;
        }
        else bikeInteract = false;
    }

    void HandleDoorInteraction(){
        if(!bikeInteracted) 
            StartCoroutine(algoritmo.HandleDefeat());
        if(!doorInteracted){
            door.rotation = new Quaternion(0, 0, 0, 0);
            door.position += new Vector3(0.2f,0,0);
            doorInteracted = true;
        }
        
    }

    IEnumerator HandleGuardaInteration(){
        if(!doorInteracted)
            StartCoroutine(algoritmo.HandleDefeat());
        if(!guardaInteracted){
            guardaInteracted = true;
            card.SetActive(true);
            yield return new WaitForSeconds(3);
            card.SetActive(false);
        }
    }

    void HandleTreeInteraction(){
        if(!guardaInteracted) StartCoroutine(algoritmo.HandleDefeat());
        Destroy(GameObject.Find("apple"));
        treeInteracted = true;
    }

    void HandleWrongBuildingInteraction(){
        StartCoroutine(algoritmo.HandleDefeat());
        canMove = false;
    }

    void HandleRightBuildingInteraction(){
        if(!treeInteracted) 
            StartCoroutine(algoritmo.HandleDefeat());
        else
            StartCoroutine(algoritmo.HandleVictory());
    }

}
