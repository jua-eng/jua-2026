
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene("Outside");
    }
}
