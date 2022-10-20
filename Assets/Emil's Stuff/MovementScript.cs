using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public XRIDefaultInputActions input;

    int movementSpeed = 10;
    CharacterController controller;
    Vector2 value;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        input = new XRIDefaultInputActions();
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
        value = new Vector2(0, 0);
    }


    // Update is called once per frame
    void Update()
    {
        input.XRIRightHandLocomotion.Move.performed += ctx => value = ctx.ReadValue<Vector2>();
        if(input.XRIRightHandLocomotion.Move.WasPerformedThisFrame() == true) 
        {
            Vector3 move = new Vector3( value.x, 0, value.y);

            controller.Move(move*Time.deltaTime*movementSpeed);
        }
    }
}
