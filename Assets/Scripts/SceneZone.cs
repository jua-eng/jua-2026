
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneZone : MonoBehaviour
{
    public GameObject prompt;
    public string Main;

    private bool playerNear;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerNear = true;
        prompt.SetActive(true);
        Debug.Log("플레이어 감지됨");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerNear = false;
        prompt.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("E 키 입력 감지!");

            if (playerNear)
            {
                Debug.Log("Main 씬으로 이동!");
                SceneManager.LoadScene(Main);
            }
            else
            {
                Debug.Log("플레이어가 구역 안에 있지 않음");
            }
        }
    }
}
