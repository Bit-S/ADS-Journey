using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

 public class EstDados : Game
 {
     public static List<Ring>[] poles;

     public TextMeshPro txtVictory;
     public GameObject questionButtons;
     public GameObject instructions;

     bool canAnswer = true;

     new void Start(){
        txtVictory.text = "";
        poles = new List<Ring>[3] { new List<Ring>(), new List<Ring>(), new List<Ring>() };
     }

     new void Update(){
         base.Update();
         if(poles[2].Count == 3){
             txtVictory.text = "Boa :)";
             StartCoroutine(ShowQuestion());
         }
     }

     public void ShowInstructions(bool show){
         instructions.SetActive(show);
     }

     public void HandleRightAnswer(){
         if(canAnswer)
            StartCoroutine(HandleVictory());
     }

     public void HandleWrongAnswer(){
         if(canAnswer) 
            StartCoroutine(HandleDefeat());
     }

     IEnumerator ShowQuestion(){
         yield return new WaitForSeconds(1);
         questionButtons.SetActive(true);
         poles = new List<Ring>[3] { new List<Ring>(), new List<Ring>(), new List<Ring>() };
         txtVictory.text = "Qual estrutura de dados \nvocê acabou de ver?";
         GameObject.Find("TorreHanoi").transform.position += new Vector3(0, -50, 0);
         Destroy(GameObject.Find("QuestionMark"));
     }

     IEnumerator HandleVictory(){
         txtVictory.text = "Boa :)";
         canAnswer = false;
         if(!estDadosCompleted){
            estDadosCompleted = true;
            SaveStatus("estDadosCompleted");
         }
         yield return new WaitForSeconds(2);
         LoadScene("Main");
     }

     IEnumerator HandleDefeat(){
         txtVictory.text = "Errou :(\nTente novamente";
         canAnswer = false;
         yield return new WaitForSeconds(3);
         LoadScene("EstDadosIntro");
     }
 }
