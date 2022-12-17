using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject[] challenge;
    private int _currentIndex;
    private void Start()
    {
        _currentIndex = PlayerPrefs.GetInt("SelectedChallenge", 0);
        
        foreach (var panel in challenge)
        {
            panel.SetActive(false);
        }
        
        challenge[_currentIndex].SetActive(true);
    }

    public void Left()
    {
        challenge[_currentIndex].SetActive(false);

        _currentIndex--;
        if (_currentIndex == -1)
            _currentIndex = challenge.Length - 1;
        
        challenge[_currentIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedChallenge", _currentIndex);
    }

    public void Right()
    {
        challenge[_currentIndex].SetActive(false);
        
        _currentIndex++;
        if (_currentIndex == challenge.Length)
            _currentIndex = 0;
        
        challenge[_currentIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedChallenge", _currentIndex);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadSocialMediaSite(string url)
    {
        Application.OpenURL(url);
    }

    public void LogOut()
    {
        Application.Quit();
    }
}
