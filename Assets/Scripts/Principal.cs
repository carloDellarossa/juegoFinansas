using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Principal : MonoBehaviour
{
    public static Principal Instance;

    //coneccion a apis
    public ApiUsuario ApiUsuario;
    //public ApiTransables ApiTransables;
    public ApiCanje ApiCanje;
    public ApiTransaccion ApiTransaccion;
    public ApiRecetas ApiRecetas;
    public ApiMiStock ApiMiStock;

    //cargar objetos
    public Usuario Usuario;
    public Canje Canje;
    public Transable Transable;
    public Transaccion Transaccion;
    public Receta Receta;
    public Stock Stock;
    public BtnCanje BtnCanje;
    public BtnProducir BtnProducir;
    public BtnLogin BtnLogin;

    public string userid = null;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        //ingresar apis al singleton
        ApiUsuario = GetComponent<ApiUsuario>();
       //ApiTransables = GetComponent<ApiTransables>();
        ApiCanje = GetComponent<ApiCanje>();
        ApiTransaccion = GetComponent<ApiTransaccion>();
        ApiRecetas = GetComponent<ApiRecetas>();
        ApiMiStock = GetComponent<ApiMiStock>();


        //ingresar objetos al singleton
        Usuario = GetComponent<Usuario>();
        Canje = GetComponent<Canje>();
        Transable = GetComponent<Transable>();
        Transaccion = GetComponent<Transaccion>();
        Receta = GetComponent<Receta>();
        Stock = GetComponent<Stock>();
        BtnCanje = GetComponent<BtnCanje>();
        BtnProducir = GetComponent<BtnProducir>();
        BtnLogin = GetComponent<BtnLogin>();

    }


}
