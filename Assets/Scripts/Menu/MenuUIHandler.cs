using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_InputField inputField;
    public void StartNew()
    {
        DataHandler.Instance.playerName = inputField.text;
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}