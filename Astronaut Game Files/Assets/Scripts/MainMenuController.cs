using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
  public void PlayGame() {
    SceneManager.LoadScene("GamePlay");
  }
  public void BackToMenu() {
    SceneManager.LoadScene("MainMenu");
  }
  public void Restart() {
    SceneManager.LoadScene("GamePlay");
  }
  public void BackgroundStory() {
    SceneManager.LoadScene("BackgroundStory");
  }
  public void Rules() {
    SceneManager.LoadScene("Rules");
  }
}
