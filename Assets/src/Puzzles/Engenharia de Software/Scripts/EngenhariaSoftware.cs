using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EngenhariaSoftware : Game{
    Atender atender;
    Compor compor;
    Estabelecimento estabelecimento;
    Funcionario funcionario;
    Garrafa garrafa;
    Lote lote;
    Retirar retirar;

    public TextMeshPro txtSentence;

    public GameObject instructions;

    void Start(){
        
        atender = GameObject.Find("atender-eng").GetComponent<Atender>();
        compor = GameObject.Find("compor-eng").GetComponent<Compor>();
        estabelecimento = GameObject.Find("estabelecimentos-eng").GetComponent<Estabelecimento>();
        funcionario = GameObject.Find("funcionarios-eng").GetComponent<Funcionario>();
        garrafa = GameObject.Find("garrafas-eng").GetComponent<Garrafa>();
        lote = GameObject.Find("lotes-eng").GetComponent<Lote>();
        retirar = GameObject.Find("retirar-eng").GetComponent<Retirar>();

    }

    void OnMouseDown() {
        if (atender.estaConectado && compor.estaConectado && estabelecimento.estaConectado && funcionario.estaConectado && garrafa.estaConectado && lote.estaConectado && retirar.estaConectado){
            StartCoroutine(HandleVictory());
        }
        else{
            StartCoroutine(HandleError());
        }
    }

    public void ShowInstructions(bool show){
        instructions.SetActive(show);
    }

    IEnumerator HandleVictory(){
        if(!engSoftwareCompleted){
            engSoftwareCompleted = true;
            SaveStatus("engSoftwareCompleted");
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
}
