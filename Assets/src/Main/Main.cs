using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main : Game
{
    public TextMeshPro txtMatDiscAproved;
    public TextMeshPro txtRedesAproved;
    public TextMeshPro txtAocAproved;
    public TextMeshPro txtBancoDadosAproved;
    public TextMeshPro txtAlgoritmoAproved;
    public TextMeshPro txtEstDadosAproved;
    public TextMeshPro txtGestaoProjetosAproved;
    public TextMeshPro txtEngSoftwareAproved;
    public TextMeshPro txtSOAproved;

    public GameObject instructions;

    new void Start()
    {
        base.Start();
        if(matDiscCompleted) txtMatDiscAproved.text = "Passou!";
        if(redesCompleted) txtRedesAproved.text = "Passou!";
        if(aocCompleted) txtAocAproved.text = "Passou!";
        if(algoritmoCompleted) txtAlgoritmoAproved.text = "Passou!";
        if(estDadosCompleted) txtEstDadosAproved.text = "Passou!";
        if(bancoDadosCompleted) txtBancoDadosAproved.text = "Passou!";
        if(gestaoProjetosCompleted) txtGestaoProjetosAproved.text = "Passou!";
        if(engSoftwareCompleted) txtEngSoftwareAproved.text = "Passou!";
        if(soCompleted) txtSOAproved.text = "Passou!";
    }

    public void ShowInstructions(bool show){
        instructions.SetActive(show);
    }

}
