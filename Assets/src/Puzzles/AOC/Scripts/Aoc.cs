using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Aoc : Game{
    Cooler cooler;
    Plaquinha plaquinha;
    Processador processador;
    Memoria1 memoria1;
    Memoria2 memoria2;

    public TextMeshPro txtSentence;

    public GameObject instructions;

    void Start(){
        cooler = GameObject.Find("cooler").GetComponent<Cooler>();
        plaquinha = GameObject.Find("placa").GetComponent<Plaquinha>();
        processador = GameObject.Find("processador").GetComponent<Processador>();
        memoria1 = GameObject.Find("memoria").GetComponent<Memoria1>();
        memoria2 = GameObject.Find("memoria2").GetComponent<Memoria2>();

    }

    void OnMouseDown() {
        if (cooler.estaConectado && plaquinha.estaConectado && processador.estaConectado && memoria1.estaConectado && memoria2.estaConectado){
            StartCoroutine(HandleVictory());
        }
        else{
            StartCoroutine(HandleError());
        }
    }

    IEnumerator HandleVictory(){
        if(!aocCompleted){
            aocCompleted = true;
            SaveStatus("aocCompleted");
        }
        txtSentence.text = "Boa :)";
        yield return new WaitForSeconds(2);
        LoadScene("Main");
    }

    IEnumerator HandleError(){
        txtSentence.text = "Continue tentando!";
        yield return new WaitForSeconds(1);
        txtSentence.text = "";
    }

    public void ShowInstructions(bool show){
        instructions.SetActive(show);
    }
}
