using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class ApiCompras : MonoBehaviour
{
    void Start()
    {
        // Servicio

        StartCoroutine(GetTransables());

    }


    public IEnumerator GetTransables()
    {
        string uri = "http://eklo.cl/juego/juegofinanzas/public/api/ofertaventa";
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            Principal.Instance.Transable.cargarTransables(www.downloadHandler.text);
        }
    }


}