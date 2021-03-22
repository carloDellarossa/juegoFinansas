using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class ApiRecetas : MonoBehaviour
{
    void Start()
    {
        // Servicio
        StartCoroutine(GetRecetas());
    }


    public IEnumerator GetRecetas()
    {
        //luego hay q cambiar el usuario
       // string actor = Principal.Instance.Usuario.getUsuario().ToString();

        string uri = "http://eklo.cl/juego/juegofinanzas/public/api/recetas";
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

            Principal.Instance.Receta.cargarRecetas(www.downloadHandler.text);

        }
    }


    public IEnumerator ComprarTransaccion()
    {
        string uri = "http://eklo.cl/juego/juegofinanzas/public/api/recetas";
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

            Principal.Instance.Receta.cargarRecetas(www.downloadHandler.text);

        }
    }
}
