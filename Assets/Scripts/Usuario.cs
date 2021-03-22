using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Usuario : MonoBehaviour
{

    public string Id;
    public string Nombre;
    public string Email;
    public string Dinero;
    public int Puntos;

    public void SetUsuario(string id, string nombre,string email,string dinero, int puntos)
    {
        Id = id;
        Nombre = nombre;
        Email = email;
        Dinero = dinero;
        Puntos = puntos;

        SetUiPerfil(id, nombre, email, dinero, puntos);

    }

    public void SetUiPerfil(string id, string nombre, string email, string dinero, int puntos)
    {
        string componentPath = "EspacioInterno/ScrollList/Viewport/Contenido/Dashboard/Usuario/";
        /*
        modificar a lista de actores
        */

        try
        {

            Text uiId = GameObject.Find(componentPath + "Id").GetComponent<Text>();
            Text uiNombre = GameObject.Find(componentPath + "Nombre").GetComponent<Text>();
            Text uiEmail = GameObject.Find(componentPath + "Email").GetComponent<Text>();
            Text uiDinero = GameObject.Find(componentPath + "Dinero").GetComponent<Text>();
            Text uiPuntos = GameObject.Find(componentPath + "Puntos").GetComponent<Text>();

            uiId.text = id.ToString();
            uiNombre.text = nombre;
            uiEmail.text = email;
            uiDinero.text = dinero;
            uiPuntos.text = puntos.ToString();

        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }

    }

    public string getUsuario()
    {
        return this.Id;
    }

    public void setUsarioId( string usuario )
    {
        this.Id = usuario;
    }
}
