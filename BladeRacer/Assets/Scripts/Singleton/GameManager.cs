using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;
    public Button nextSceneButton;

    private void Start()
    {
        _sessionStartTime = DateTime.Now;
        Debug.Log("게임 시작 시간 : " + _sessionEndTime);
        nextSceneButton.GetComponentInChildren<TextMeshProUGUI>().text = "NextScene";
        nextSceneButton.onClick.AddListener(OnNextSceneButtonClick);
    }

    private void OnApplicationQuit()
    {
        _sessionEndTime = DateTime.Now;
        TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);
        
        Debug.Log("게임 종료 시간 : " + _sessionEndTime);
        Debug.Log("총 플레이 시간 : " + timeDifference);
    }

    private static void OnNextSceneButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
