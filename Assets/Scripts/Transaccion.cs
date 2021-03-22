using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System;

public class Transaccion : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }


    public void cargarTransacciones(string jsonArray)
    {
        JSONArray transaccion = JSON.Parse(jsonArray) as JSONArray;
        string componentPath = "HistorialDeMovimientos/Contenido/transaccionItem";

        for (int i = 0; i < transaccion.Count; i++)
        {

            GameObject item = Instantiate(Resources.Load("transaccionItem") as GameObject);
            try
            {

                item.transform.SetParent(GameObject.Find("HistorialDeMovimientos/Popup/Contenido").transform);
                item.transform.localScale = Vector3.one;
                item.transform.localPosition = Vector3.zero;

                //armar cabezera
                string Actor = transaccion[i]["actor"];
                string Descripcion = transaccion[i]["descripcion"];

                Text uiActor = item.transform.Find("Cabezera/Actor").GetComponent<Text>();
                Text uiDescripcion = item.transform.Find("Cabezera/Descripcion").GetComponent<Text>();

                uiActor.text = Actor;
                uiDescripcion.text = Descripcion;


                //armar detalle debe
                Debug.Log(transaccion[i]["detalle"][0]);

                string cuentaa = transaccion[i]["detalle"][0]["cta_contable"]["nombre"];
                string tipoMOva = transaccion[i]["detalle"][0]["tipoMov"];
                string productoa = transaccion[i]["detalle"][0]["producto"]["nombre"];
                string cantidada = transaccion[i]["detalle"][0]["cantidad"];
                string montoa = transaccion[i]["detalle"][0]["monto"];

                Text uicuentaa = item.transform.Find("DetalleDebe/cuenta").GetComponent<Text>();
                Text uitipoMOva = item.transform.Find("DetalleDebe/tipoMOv").GetComponent<Text>();
                Text uiproductoa = item.transform.Find("DetalleDebe/producto").GetComponent<Text>();
                Text uicantidada = item.transform.Find("DetalleDebe/cantidad").GetComponent<Text>();
                Text uimontoa = item.transform.Find("DetalleDebe/monto").GetComponent<Text>();

                uicuentaa.text = cuentaa;
                uitipoMOva.text = tipoMOva;
                uiproductoa.text = productoa;
                uicantidada.text = cantidada;
                uimontoa.text = montoa;

                //armar detalle haber
                string cuentad = transaccion[i]["detalle"][1]["cta_contable"]["nombre"];
                string tipoMOvd = transaccion[i]["detalle"][1]["tipoMov"];
                string productod = transaccion[i]["detalle"][1]["producto"]["nombre"];
                string cantidadd = transaccion[i]["detalle"][1]["cantidad"];
                string montod = transaccion[i]["detalle"][1]["monto"];

                Text uicuentad = item.transform.Find("DetalleHaber/cuenta").GetComponent<Text>();
                Text uitipoMOvd = item.transform.Find("DetalleHaber/tipoMOv").GetComponent<Text>();
                Text uiproductod = item.transform.Find("DetalleHaber/producto").GetComponent<Text>();
                Text uicantidadd = item.transform.Find("DetalleHaber/cantidad").GetComponent<Text>();
                Text uimontod = item.transform.Find("DetalleHaber/monto").GetComponent<Text>();

                uicuentad.text = cuentad;
                uitipoMOvd.text = tipoMOvd;
                uiproductod.text = productod;
                uicantidadd.text = cantidadd;
                uimontod.text = montod;
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e);
            }




        }

    }
}
