using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class BtnCanje : MonoBehaviour
{
    public Button canjeBtn;

    // Start is called before the first frame update
    void Start()
    {
        canjeBtn.onClick.AddListener(() =>
        {
            string id = canjeBtn.transform.parent.Find("id").GetComponent<Text>().text;

            //Text cantidad = canjeBtn.transform.parent.Find("catidad").GetComponent<Text>();

            string texto = canjeBtn.GetComponentInChildren<Text>().text;

            //int usuario = Principal.Instance.Usuario.getUsuario();
            // Debug.Log(usuario);

            //llamar a funcon de canje de puntos-
            StartCoroutine( cangearPuntos(id) );
        }
        );
    }


    public IEnumerator cangearPuntos(string id)
    {
        WWWForm form = new WWWForm();

        string idCanje = id.ToString();
        string descripcion = "canje puntos";
        string actor = Principal.Instance.Usuario.getUsuario().ToString();

        form.AddField("actor", actor);
        form.AddField("descripcion", descripcion);
       // form.AddField("licitacion", null);
      //  form.AddField("programa", null);
        form.AddField("idCanje", idCanje);

        string uri = "http://eklo.cl/juego/juegofinanzas/public/api/transacciones/canjearpuntos";
        UnityWebRequest www = UnityWebRequest.Post(uri, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            StartCoroutine(Principal.Instance.ApiUsuario.GetDatosUruario(actor));
            Debug.Log("Canje exitoso");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
