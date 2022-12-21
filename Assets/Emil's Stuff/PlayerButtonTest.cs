using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerButtonTest : MonoBehaviour
{
    XRIDefaultInputActions input;
    public GameObject obj;
    public GameObject RightController;

    [SerializeField]
    Text testText;

    //Loads the next scene in the order. - Elio 
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        input = new XRIDefaultInputActions();
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (input.XRIRightHandInteraction.Activate.WasPressedThisFrame() && Physics.Raycast(RightController.transform.position, RightController.transform.forward, out hit, 100)) 
        {
            Instantiate(obj, hit.point, Quaternion.identity);
            testText.text = "Instasiated";
        }

        //Loads the next scene when you press trigger
        if (input.XRILeftHandInteraction.Activate.WasPressedThisFrame() == true)
        {
            LoadNextScene();
        }

        /*Ray ray = new Ray(RightController.transform.position, RightController.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            
        }
        if (input.XRIRightHandInteraction.Activate.WasPressedThisFrame() && Physics.Raycast(ray, out hit, 100)) 
        {
            testText.text = "Instantiated";
            Instantiate(obj, hit.point, Quaternion.identity);
        }*/

    }
}
