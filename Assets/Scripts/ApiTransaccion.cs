﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class ApiTransaccion : MonoBehaviour
{
    void Start()
    {
        // Servicio
        StartCoroutine(GetTransaccion());
    }


    public IEnumerator GetTransaccion()
    {
        //luego hay q cambiar el usuario
        string actor = Principal.Instance.Usuario.getUsuario().ToString();

        string uri = "http://eklo.cl/juego/juegofinanzas/public/api/transacciones/" + actor;
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

            Principal.Instance.Transaccion.cargarTransacciones(www.downloadHandler.text);

        }
    }


    public IEnumerator ComprarTransaccion()
    {
        string uri = "http://eklo.cl/juego/juegofinanzas/public/api/ransables";
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

            Principal.Instance.Transaccion.cargarTransacciones(www.downloadHandler.text);

        }
    }

}