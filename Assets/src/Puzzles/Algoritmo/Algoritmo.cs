using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Algoritmo : Game
{
    public GameObject instructions;
    public TextMeshPro txtGameOver;

    public void ShowInstructions(bool show){
        instructions.SetActive(show);
    }

    public IEnumerator HandleVictory(){
        if(!algoritmoCompleted){
            algoritmoCompleted = true;
            SaveStatus("algoritmoCompleted");
        }
        txtGameOver.text = "Boa :)";
        yield return new WaitForSeconds(2);
        LoadScene("Main");
    }  

    public IEnumerator HandleDefeat(){
        txtGameOver.text = "As instruções não foram seguidas corretamente :(";
        yield return new WaitForSeconds(3);
        LoadScene("AlgoritmoGame");
    }
}
