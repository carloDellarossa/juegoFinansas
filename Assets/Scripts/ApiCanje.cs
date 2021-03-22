using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;


public class ApiCanje : MonoBehaviour
{
    void Start()
    {
        // Servicio
        StartCoroutine(GetCanjes());
       // StartCoroutine(GetTransables());

    }

    public IEnumerator GetCanjes()
    {
        string uri = "http://eklo.cl/juego/juegofinanzas/public/api/canje";
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

            
            Principal.Instance.Canje.cargarCanjes(www.downloadHandler.text);

        }
    }
    /*
    public IEnumerator cangearPuntos(Text id)
    {
        string uri = "";



        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpErr-or)
        {
            Debug.Log(www.error);
        }
        else
        {


            Principal.Instance.Transable.cargarTransables(www.downloadHandler.text);

        }
    }

    */


}
