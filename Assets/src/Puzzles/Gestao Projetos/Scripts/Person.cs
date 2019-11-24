using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : GestaoProjetos
{
    public RectTransform boatPos;
    public bool onBoat = false;
    public Vector3 initialPosition;
    public RectTransform rectTransform;
    float m_XAxis, m_YAxis;

    new void Start(){
        rectTransform = GetComponent<RectTransform>();
        initialPosition = transform.position;
    }

    void OnMouseDown(){
        if(onBoat) {
            GetOutBoat();
        }
        else {
            if(CanGetIn()) 
                GetInBoat();
        }
    }

    void GetOutBoat(){
        transform.position = initialPosition;
        boat.Remove(gameObject.name);
        if(boat.Count == 1)
            GameObject.Find(boat[0]).transform.position = new Vector3(boatPos.transform.position.x - 1, boatPos.transform.position.y, transform.position.z);
        onBoat = false;
        if(MoveBoat.direction == "right")
            leftSide.Add(gameObject.name);
        else
            rightSide.Add(gameObject.name);
        //this.transform.parent = null;
    }

    void GetInBoat(){
        int xPos = boat.Count == 0 ? -1 : 1;
        transform.position = new Vector3(boatPos.transform.position.x + xPos, boatPos.transform.position.y, transform.position.z);
        boat.Add(gameObject.name);
        if(leftSide.Contains(gameObject.name))
            leftSide.Remove(gameObject.name);
        if(rightSide.Contains(gameObject.name))
            rightSide.Remove(gameObject.name);
        onBoat = true;
        //this.transform.parent = boatPos;
    }

    bool CanGetIn(){
        return !(MoveBoat.direction == "right" && rightSide.Contains(gameObject.name) ||
                MoveBoat.direction == "left" && leftSide.Contains(gameObject.name)) &&
                boat.Count < 2;
    }
}
