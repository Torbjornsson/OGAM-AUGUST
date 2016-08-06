using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UserInterfaceUtilities : MonoBehaviour {

    public Image LoadingScreen;
    private Color loadingColor;
    private bool loadingScreenActive = false;
    private float loadingAlphaValue = 0.05f;
    public Text LevelText;
    private Color levelColor;
    private float levelAlphaValue = 0.1f;
    private float LoadingDuration = 1;

    void OnLevelWasLoaded(int i)
    {
        if (!SceneManager.GetActiveScene().name.Equals("SetupScene"))
        {
            ToggleLoadingScreen(true);
            LevelText.text = SceneManager.GetActiveScene().name;
        }

        Invoke("FadeOutLoadingScreen", LoadingDuration);
    }

    void Start()
    {
        loadingColor = LoadingScreen.color;
        levelColor = LevelText.color;
    }

    void Update()
    {
        FadeLoadingScreen();
    }

    void FadeOutLoadingScreen()
    {
        ToggleLoadingScreen(false);
    }

    private void FadeLoadingScreen()
    {
        if (loadingScreenActive) { loadingColor.a += loadingAlphaValue; } 
        else { loadingColor.a -= loadingAlphaValue; }
 
        if(LoadingScreen.color.a == 1)
        {
            LevelText.text = SceneManager.GetActiveScene().name;
            levelColor.a += levelAlphaValue;
        }
        else
        {
            levelColor.a -= levelAlphaValue * 2;
        }

        loadingColor.a = Mathf.Clamp(loadingColor.a, 0, 1);
        levelColor.a = Mathf.Clamp(levelColor.a, 0, 1);

        LevelText.color = levelColor;
        LoadingScreen.color = loadingColor;
    }

    public void ToggleLoadingScreen(bool b)
    {
        loadingScreenActive = b;
    }
}
