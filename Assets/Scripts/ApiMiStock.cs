using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class ApiMiStock : MonoBehaviour
{
    void Start()
    {
        // Servicio
   
        StartCoroutine(GetStock());

    }


    public IEnumerator GetStock()
    {
        string actor = Principal.Instance.Usuario.getUsuario().ToString();
        Debug.Log(actor);

        string uri = "http://eklo.cl/juego/juegofinanzas/public/api/actores/" + actor+"/stock";
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {


            Principal.Instance.Stock.cargarStock(www.downloadHandler.text);

        }
    }

    
}