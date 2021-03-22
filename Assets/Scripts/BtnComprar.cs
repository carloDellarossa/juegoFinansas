using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class BtnComprar : MonoBehaviour
{
    public Button comprarBtn;
    public Text precio;
    public InputField cantidad;
    public Text id;
    public Text proveedor;
    public Text nombre;
    public Text unidad;

    // Start is called before the first frame update
    void Start()
    {
        comprarBtn.onClick.AddListener(() =>
        {
            StartCoroutine(setPrecio(precio.text, cantidad.text, id.text, proveedor.text, nombre.text, unidad.text));
        }
        );
    }


    public IEnumerator setPrecio(string precio, string cantidad, string id, string proveedor, string nombre, string unidad)
    {
        WWWForm form = new WWWForm();

        string actor = Principal.Instance.Usuario.getUsuario().ToString();
        form.AddField("vendedor", proveedor);
        form.AddField("comprador", actor);
        form.AddField("descripcion", nombre);

        Debug.Log(proveedor);
        Debug.Log(actor);
        Debug.Log(id);
        Debug.Log(cantidad);

        form.AddField("detalle[0][transable]", id);
        form.AddField("detalle[0][cantidad]", cantidad);
        form.AddField("detalle[0][umedida]", unidad);
        form.AddField("detalle[0][precio]", precio);
        form.AddField("detalle[0][descripcion]", nombre);

        /*
        form.AddField("stock_id", id);
        form.AddField("precio", precio);
        form.AddField("cantidad_ofertada", cantidad);
        */

        string uri = "http://eklo.cl/juego/juegofinanzas/public/api/transacciones/compramaterial";
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