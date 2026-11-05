
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    public FirstPersonMover mover;

    private Exhibit nearby;
    private GameObject openPanel;

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (openPanel != null)
            {
                openPanel.SetActive(false);
                openPanel = null;

                mover.enabled = true;

                if (nearby != null)
                    nearby.ShowPrompt(true);
            }
            else if (nearby != null && nearby.panel != null)
            {
                openPanel = nearby.panel;
                openPanel.SetActive(true);

                nearby.ShowPrompt(false);

                mover.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Exhibit e = other.GetComponent<Exhibit>();
        if (e == null) return;

        nearby = e;
        nearby.ShowPrompt(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Exhibit e = other.GetComponent<Exhibit>();
        if (e == null || e != nearby) return;

        nearby.ShowPrompt(false);
        nearby = null;
    }
}
