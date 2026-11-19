using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string Outside;   // 넘어갈 씬 이름

    public void Load()
    {
        SceneManager.LoadScene(Outside);
    }
}
