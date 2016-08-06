using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public Slider UIHealthBar;
    public Text UIHealthText;
    GameObject Player;
    PlayerResources PR;
    private float healthSegmentDrop = 0.1f;
    int textHealthint = 0;

    [SerializeField]
    private string[] doNotLoadOn = { "SetupScene" };

    void OnLevelWasLoaded()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SetActiveToBool(true);
        foreach (string s in doNotLoadOn)
        {
            if (s.Equals(sceneName))
            {
                SetActiveToBool(false);
            }
        }
    }

    void SetActiveToBool(bool b)
    {
        UIHealthBar.gameObject.SetActive(b);
        UIHealthText.gameObject.SetActive(b);
    }

    void Update()
    {
        
        if (!UIHealthBar || !UIHealthBar.enabled) { print("Missing Health bar slider on " + gameObject.name); return; }
        if(!UIHealthText || !UIHealthText.enabled) { print("Missing Health bar text on " + gameObject.name); return; }
        

        if (!Player) { Player = GameObject.FindGameObjectWithTag("Player"); }
        else if (!PR) { PR = Player.GetComponent<PlayerResources>(); }
        else 
        {
            if (UIHealthBar)
            { 
                UIHealthBar.maxValue = PR.GetMaxHealth();
                UIHealthBar.value += (PR.GetHealth() - UIHealthBar.value) * healthSegmentDrop;
                UIHealthBar.value = Mathf.Clamp(UIHealthBar.value, 0, UIHealthBar.maxValue);

                if (UIHealthText)
                {
                    textHealthint = (int) (UIHealthBar.value + 0.1f);
                    UIHealthText.text = textHealthint.ToString();
                }
            }
        }


        
    }

}
