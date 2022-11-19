using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : PlayerComponent
{ 
    public int red_frog_amount = 0;
    public int blue_frog_amount = 0;
    public int green_frog_amount = 0;

    public int torches_amount = 0;
    public int leaves_amount = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable")
        {
            switch (other.gameObject.GetComponent<PickUp>().type)
            {
                case Epickup.RED_FROG:
                    red_frog_amount++;
                    break;
                case Epickup.BLUE_FROG:
                    blue_frog_amount++;
                    break;
                case Epickup.GREEN_FROG:
                    green_frog_amount++;
                    break;
                case Epickup.TORCH:
                    torches_amount++;
                    break;
                case Epickup.LEAVES:
                    leaves_amount++;
                    break;
                default:
                    break;
            }
            Destroy(other.gameObject);
        }
    }
}
