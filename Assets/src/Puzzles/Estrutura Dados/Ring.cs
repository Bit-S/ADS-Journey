using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : EstDados
 {
     public int size;
     
     int poleNumber = 0; 
     int nearestPoleNumber;
 
     bool isBeingDragged = false;
     Vector3 mousePos; 

     public Transform pole1;
     public Transform pole2;
     public Transform pole3;
 
     new void Start ()
     {
         Invoke("AddRingToPole", 0.3f);
     }

     new void Update(){
         if(Near(pole1)) nearestPoleNumber = 0;
         if(Near(pole2)) nearestPoleNumber = 1;
         if(Near(pole3)) nearestPoleNumber = 2;
     }

     void AddRingToPole()
     {
         poles[poleNumber].Add(this as Ring);
     }
 
     void OnMouseDown ()
     {
         int minSize = 99999;
         foreach (Ring ring in poles[poleNumber])
         {
             if (ring.size < minSize)
                 minSize = ring.size;
         }
 
         if (size == minSize)
            isBeingDragged = true;
         
     }
 
     void OnMouseDrag ()
     {
         if (isBeingDragged)
         {
            mousePos = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
		    mousePos.z = 0;
		    transform.position = mousePos;
         }
     }
 
     void OnMouseUp ()
     {
 
        int minSize = 4;

        foreach (Ring ring in poles[nearestPoleNumber]) {

            if (ring.size < minSize)
                minSize = ring.size;
            
        }

        if (size < minSize){
            poles[poleNumber].Remove(this as Ring);
            poles[nearestPoleNumber].Add(this as Ring);
            poleNumber = nearestPoleNumber;
        } 

        GoToPole(); 
        
        isBeingDragged = false;
    }

    void GoToPole(){
        float posY = transform.position.y;

        if(isBeingDragged) posY = 2;

        if(poleNumber == 0)
            transform.position = new Vector3(-6, posY, transform.position.z);
        else if(poleNumber == 1)
            transform.position = new Vector3(-0.2f, posY, transform.position.z);
        else
            transform.position = new Vector3(5.5f, posY, transform.position.z);
    }

    protected bool Near(Transform other){
        return Mathf.Abs(this.transform.position.x - other.position.x) < 2;
    }
 }

