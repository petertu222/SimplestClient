using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystemManager : MonoBehaviour
{
    GameObject inputFieldUsername, inputFieldPassword, buttonSubmit, toggleLogin, toggleCreate;

    GameObject networkedClient;
    // Start is called before the first frame update
    void Start()
    {

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allObjects)
        {
            if (go.name == "InputFieldUsername")
                inputFieldUsername = go;
            else if (go.name == "InputFieldPassword")
                inputFieldPassword = go;
            else if (go.name == "ButtonSubmit")
                buttonSubmit = go;
            else if (go.name == "ToggleLogin")
                toggleLogin = go;
            else if (go.name == "ToggleCreate")
                toggleCreate = go;
            else if (go.name == "NetworkedClient")
                networkedClient = go;

        }

        buttonSubmit.GetComponent<Button>().onClick.AddListener(SubmitButtonPressed);
        toggleCreate.GetComponent<Toggle>().onValueChanged.AddListener(ToggleCreateValueChanged);
        toggleLogin.GetComponent<Toggle>().onValueChanged.AddListener(ToggleLoginValueChanged);

        //inputFieldUsername.GetComponent<InputField>().onEndEdit.AddListener()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SubmitButtonPressed()
    {
        string n = inputFieldUsername.GetComponent<InputField>().text;
        string p = inputFieldUsername.GetComponent<InputField>().text;

        if (toggleLogin.GetComponent<Toggle>().isOn)
            networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.Login + "," + n + "," + p);
        else
            networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.CreateAccount + "," + n + "," + p);
    }
    public void ToggleCreateValueChanged(bool newValue)
    {
        toggleCreate.GetComponent<Toggle>().SetIsOnWithoutNotify(!newValue);
    }
    public void ToggleLoginValueChanged(bool newValue)
    {
        toggleLogin.GetComponent<Toggle>().SetIsOnWithoutNotify(!newValue);

    }
}

public static class ClientToServerSignifiers
{
    public const int Login = 1;
    public const int CreateAccount = 2;
}

public static class ServerToClientSignifiers
{
    public const int LoginResponse = 1;

    //public const int LoginFailure = 2;

    //public const int CreateAccountSuccess = 1;
    //public const int CreateAccountFailure = 2;
}
public static class LoginResponses
{
    public const int Success = 1;

    public const int FailureNameInUse = 2;

    public const int FailureNameNotFound = 3;

    public const int FailureNameIncorrectPassword = 4;
}