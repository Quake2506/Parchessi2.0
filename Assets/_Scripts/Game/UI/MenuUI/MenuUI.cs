using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MenuUI : MonoBehaviour
{
    [FormerlySerializedAs("optionMenu")] public GameObject OptionMenu;
    [FormerlySerializedAs("mainMenu")] public GameObject MainMenu;

    public void LoadLobby()
    {
        MainMenu.LeanScale(Vector2.zero, .3f).setEaseInBack().setOnComplete(Play);
    }
    
    public void OnOptionOpen()
    {
        MainMenu.LeanScale(Vector2.zero, .3f).setEaseInBack().setOnComplete(OptionEnable);
        OptionMenu.LeanScale(Vector2.one, 0.5f);
    }

    public void OnOptionClose()
    {
        OptionMenu.LeanScale(Vector2.zero, .3f).setEaseInBack().setOnComplete(OptionDisable);
        MainMenu.LeanScale(Vector2.one, 0.5f);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OptionEnable()
    {
        OptionMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void OptionDisable()
    {
        OptionMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void MainMenuEnable()
    {
        OptionMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void MainMenuDisable()
    {
        OptionMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void Play()
    {
        AssetSceneManager.LoadScene(AssetSceneManager.AssetScene.LobbyScene.ToString());
    }
}
