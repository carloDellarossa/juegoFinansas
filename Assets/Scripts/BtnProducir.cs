using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class BtnProducir : MonoBehaviour
{
    public Button producirBtn;
    public InputField cantidad;
    public Text id;

    // Start is called before the first frame update
    void Start()
    {
        producirBtn.onClick.AddListener(() =>
        {
            StartCoroutine(cangearPuntos(id.text, cantidad.text));
        }
        );
    }


    public IEnumerator cangearPuntos(string id, string cantidad)
    {
        WWWForm form = new WWWForm();

        string actor = Principal.Instance.Usuario.getUsuario().ToString();
        //string actor = "1";

        form.AddField("id_receta", id);
        form.AddField("actor", actor);
        form.AddField("cantidad", cantidad);

        string uri = "http://eklo.cl/juego/juegofinanzas/public/api/transables/producir";
        UnityWebRequest www = UnityWebRequest.Post(uri, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
