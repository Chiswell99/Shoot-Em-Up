using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboardListener : MonoBehaviour, IInputeable
{
    
    public void GetDirection(Vector3 direction)
    {
        InputProvider.TriggerDirection(direction);
    }
    public void ShootPressed()
    {
        InputProvider.TriggerOnHasShoot();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ShootPressed();
        }


        GetDirection(new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));


    }

    //public void MoveButtonX()
    //{
    //    newDirection = new Vector3(1, 0, 0);
    //    Debug.Log("Entro al X");
    //}

    //public void MoveButtonY()
    //{
    //    newDirection = new Vector3(0, 1, 0);
    //    Debug.Log("Entro al Y");

    //}


}
