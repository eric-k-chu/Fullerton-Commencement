using UnityEngine;

public class GraduationZone : MonoBehaviour
{
    public GameObject graduateUI;

    private bool inZone;


    private void Start()
    {
        inZone = false;   
    }

    private void OnTriggerEnter()
    {
        inZone = true;
        graduateUI.SetActive(true);
    }

    private void OnTriggerExit()
    {
        inZone = false;
        graduateUI.SetActive(false);
    }

    private void Update()
    {
        if (inZone && Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                EventManager.instance.EndGraduation();
                graduateUI.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
