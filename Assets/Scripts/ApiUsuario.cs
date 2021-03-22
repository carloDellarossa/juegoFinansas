using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class ApiUsuario : MonoBehaviour
{

    void Start()
    {
        try
        {
         StartCoroutine(GetDatosUruario(Principal.Instance.userid));
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
    }

    public IEnumerator GetDatosUruario(string usuario)
    {
        Debug.Log(usuario);

        string uri = "http://eklo.cl/juego/juegofinanzas/public/api/actores/" + usuario;
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

            var respuesta = JSON.Parse(www.downloadHandler.text);

        
             Principal.Instance.Usuario.SetUsuario(respuesta["id"], respuesta["nombre"], respuesta["usuario"]["email"], respuesta["dinero"], respuesta["totalpuntos"]);

            

            
        }
    }




    



}
