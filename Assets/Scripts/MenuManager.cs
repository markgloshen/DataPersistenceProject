using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public string currentName;
    
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI highScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.LoadScore();
        highScoreText.text = "High Score: " + ScoreManager.Instance.bestName + " : " + ScoreManager.Instance.bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName()
    {
        ScoreManager.Instance.currentName = inputField.text;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
