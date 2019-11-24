using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MatDisc : Game
{
    
    byte[] trueAnswers = {0, 3, 4, 6, 7};
    static byte round;

    string[] sentences = {
        "O conjunto dos números naturais é subconjunto do conjunto dos inteiros\nAND\npi é um número racional",
        "-2 é um número natural\nOR\n6,34534 ∉ Q", 
        "Não existe divisão por 0\nOR\nAs dízimas periódicas não fazem parte do conjunto dos racionais",
        "Função é uma regra que relaciona cada elemento de um conjunto a um único elemento de outro conjunto\nAND\nBhaskara é usado em equações de segundo grau",
        "2 + 2 = 4\nXOR\nTodo número elevado a 0 é igual a 1",
        "Nem todo número primo possui apenas 2 divisores\nXOR\nx * 0 = 0, x ∈ ℝ",
        "A FATEC é muito bem conceituada no mercado\nAND\n1+1=2"
    };

    public Text txtSentence;
    public GameObject instructions;

    new void Start(){
        round = 0;
    }

    public void ShowInstructions(bool show){
        instructions.SetActive(show);
    }

    public void BtnTruePressed(){
        if(round == 7) 
            StartCoroutine(HandleVictory());
        else {
            if(Contains(trueAnswers, round))
                GoToNextSentence();
            else 
                HandleDefeat();
        }
    }

    public void BtnFalsePressed(){
        if(!Contains(trueAnswers, round))
            GoToNextSentence();
        else 
            HandleDefeat();
    }

    void HandleDefeat(){
        txtSentence.text = "\t Errou :(   \t";
        GameObject.Find("btnTrue").SetActive(false);
        GameObject.Find("btnFalse").SetActive(false);
    }

    IEnumerator HandleVictory(){
        txtSentence.text = "\t Boa :)    \t";
        if(!matDiscCompleted){
            matDiscCompleted = true;
            SaveStatus("matDiscCompleted");
        }
        GameObject.Find("btnTrue").SetActive(false);
        GameObject.Find("btnFalse").SetActive(false);
        yield return new WaitForSeconds(3);
        LoadScene("Main");
    }

    void GoToNextSentence(){
        txtSentence.text = sentences[round];
        round++;
    }

    bool Contains(byte[] array, byte n){
        foreach(byte i in array){
            if(i == n)
                return true;
        }
        return false;
    }

}
