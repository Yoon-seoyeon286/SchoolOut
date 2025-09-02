using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public void OutGame()
    {
        Application.Quit();
    }

    public void ReGame()
    {
        SceneManager.LoadScene("schoolMain");
    }
}
