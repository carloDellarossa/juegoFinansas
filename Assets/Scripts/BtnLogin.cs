using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using System;

public class BtnLogin : MonoBehaviour
{
    public Button loginBtn;
    public InputField Usuario;
    public InputField Password;
    public Text Mensaje;
    public Button panelChangeBtn;


    // Start is called before the first frame update
    void Start()
    {


        loginBtn.onClick.AddListener(() =>
        {
            Login(Usuario.text, Password.text);
        });

    }

    public void Login(string Usuario, string Password)
    {

        try
        {
            if (Usuario == "Comprador" && Password == "comprador2021")
            {
                postLogin(true, "3");
            }
            else if (Usuario == "Proveedor" && Password == "proveedor2021")
            {
                postLogin(true, "1");
            }
            else
            {
               // Mensaje.text = 
                Text uiMensaje = GameObject.Find("LoginCanvas/Login/Mensaje/Text").GetComponent<Text>();
                uiMensaje.text = " Usuario o Clave incorrectos";
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
    }


    public void postLogin(bool login, string id)
    {
        if (login)
        {

            Principal.Instance.userid = id;
            panelChangeBtn.onClick.Invoke();

        }
    }


}



