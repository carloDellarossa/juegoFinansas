using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class BtnPrecio : MonoBehaviour
{
    public Button publicarBtn;
    public InputField precio;
    public InputField cantidad;
    public Text id;

    // Start is called before the first frame update
    void Start()
    {
        publicarBtn.onClick.AddListener(() =>
        {
            StartCoroutine(setPrecio(id.text, cantidad.text, precio.text));
        }
        );
    }


    public IEnumerator setPrecio(string id, string cantidad, string precio)
    {
        Debug.Log(id);
        Debug.Log(cantidad);

        WWWForm form = new WWWForm();

        string actor = Principal.Instance.Usuario.getUsuario().ToString();


        form.AddField("vendedor", actor);
        form.AddField("stock_id", id);
        form.AddField("precio", precio); 
        form.AddField("cantidad_ofertada", cantidad);
  


        string uri = "http://eklo.cl/juego/juegofinanzas/public/api/ofertaventa/crear";
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