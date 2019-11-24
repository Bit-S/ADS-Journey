using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveBoat : GestaoProjetos
{
    public static string direction = "right";
    List<string> newRightSide;
    List<string> newLeftSide;

    void OnMouseDown(){

        if(CanMove()){
            leftSide = newLeftSide;
            rightSide = newRightSide;

            Rotate();
            Move();

            if(rightSide.Count == 8)
                StartCoroutine(HandleVictory());
        } else {
            ShowText();
        }
    }

    bool CanMove(){
        if(!HasDriver())
            return false;

        newRightSide = new List<string>();
        CopyList(rightSide, newRightSide);

        newLeftSide = new List<string>();
        CopyList(leftSide, newLeftSide);

        if(direction == "right"){
            foreach(var person in boat){
                newRightSide.Add(person);
            }
        }

        if(direction == "left"){
            foreach(var person in boat){
                newLeftSide.Add(person);
            }
        }
        
        if(newRightSide.Contains("Preguiçoso") && !newRightSide.Contains("Gerente") && newRightSide.Count > 1)
            return false;
        if(newRightSide.Contains("Lider back") && (newRightSide.Contains("Membro front1") || newRightSide.Contains("Membro front2")) && !newRightSide.Contains("Lider front"))
            return false;
        if(newRightSide.Contains("Lider front") && (newRightSide.Contains("Membro back1") || newRightSide.Contains("Membro back2")) && !newRightSide.Contains("Lider back"))
            return false;

        if(newLeftSide.Contains("Preguiçoso") && !newLeftSide.Contains("Gerente") && newLeftSide.Count > 1)
            return false;
        if(newLeftSide.Contains("Lider back") && (newLeftSide.Contains("Membro front1") || newLeftSide.Contains("Membro front2")) && !newLeftSide.Contains("Lider front"))
            return false;
        if(newLeftSide.Contains("Lider front") && (newLeftSide.Contains("Membro back1") || newLeftSide.Contains("Membro back2")) && !newLeftSide.Contains("Lider back"))
            return false;
        return true;
    }

    bool HasDriver(){
        return boat.Contains("Gerente") || boat.Contains("Lider back") || boat.Contains("Lider front");
    }

    void Move(){
        int directionAux = direction == "right" ? 1 : -1;
        Vector2 screenPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/1.1f, Screen.height));
        transform.position += new Vector3(screenPos.x * directionAux,0,0);
        UnboardPeople(directionAux);
        boat.Clear();
        direction = directionAux == 1 ? "left" : "right";
    }

    void UnboardPeople(int directionAux){

        foreach(var personName in boat){
            GameObject person = GameObject.Find(personName);
            Vector2 screenPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/0.8f, Screen.height));
            Vector3 finalPosition = person.GetComponent<Person>().initialPosition + new Vector3((screenPos.x)*directionAux,0,0);
            person.GetComponent<Person>().transform.position = finalPosition;
            person.GetComponent<Person>().initialPosition = finalPosition;
            person.GetComponent<Person>().onBoat = false;
        }   
    }

    void Rotate(){
        if(direction == "right")
            transform.rotation = new Quaternion(0,180,0,0);
        else
            transform.rotation = Quaternion.identity;
    }

    void ShowText(){
        txtCantMove.text = "Não!";
        Invoke("HideText", 1.5f);
    }

    void HideText(){
        txtCantMove.text = "";
    }

}
