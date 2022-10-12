using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    //PickupController le informa a GameController;
    public PickupConfig config;
    public void OnPickedUp()
    {
        GameController.Instance.OnPickupPickedUp(this);
    }
}
