using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BancoDados : Game
{

    public GameObject toggle1;
    public GameObject toggle2;
    public GameObject toggle3;
    public GameObject toggle4;
    public GameObject toggle5;
    public GameObject toggle6;

    public Image quadro;

    public Sprite vazio;
    public Sprite cheio;
    public Sprite query1;
    public Sprite query2;

    public Text txtSentence;

    static byte round;

    void Start(){
        round = 0;

	}

    void Update(){

    }

    public void BtnTruePressed(){
        if (round==0){
            if((toggle1.GetComponent<Toggle>().isOn) && (toggle3.GetComponent<Toggle>().isOn) && (toggle6.GetComponent<Toggle>().isOn)) 
                StartCoroutine(HandleVictory());
            else {
                StartCoroutine(HandleDefeat());
            } 
        }
        else{
            if((toggle1.GetComponent<Toggle>().isOn) && (toggle6.GetComponent<Toggle>().isOn)) 
                StartCoroutine(HandleVictory());
            else {
                StartCoroutine(HandleDefeat());
            }
        }
    }

    IEnumerator HandleVictory(){
        if (round==0){
            txtSentence.text = "\t Boa :), agora só falta mais uma \t";
            banDadosCompleted = true;
            toggle1.GetComponent<Toggle>().isOn = false;
            toggle2.GetComponent<Toggle>().isOn = false;
            toggle3.GetComponent<Toggle>().isOn = false;
            toggle4.GetComponent<Toggle>().isOn = false;
            toggle5.GetComponent<Toggle>().isOn = false;
            toggle6.GetComponent<Toggle>().isOn = false;
            yield return new WaitForSeconds(3);
            quadro.GetComponent<Image>().sprite = query2;
            txtSentence.text = "\t \t";
            round = 1;
        }
        else if (round==1){
            txtSentence.text = "\t Você conseguiu :) \t";
            banDadosCompleted = true;
            yield return new WaitForSeconds(3);
            round = 0;
            LoadScene("Main");
        }
    }

    IEnumerator HandleDefeat(){
        txtSentence.text = "\t Não foi dessa fez :(, tente novamente \t";
        yield return new WaitForSeconds(3);
        txtSentence.text = "\t \t";
        toggle1.GetComponent<Toggle>().isOn = false;
        toggle2.GetComponent<Toggle>().isOn = false;
        toggle3.GetComponent<Toggle>().isOn = false;
        toggle4.GetComponent<Toggle>().isOn = false;
        toggle5.GetComponent<Toggle>().isOn = false;
        toggle6.GetComponent<Toggle>().isOn = false;
    }

    void GoToNextQuery(){
        round++;
    }
}