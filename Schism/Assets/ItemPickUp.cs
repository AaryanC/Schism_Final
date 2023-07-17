using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

 private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Players"))
        {
            PickUp();
        }
    }

void PickUp ()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        
        if(wasPickedUp)
        {
            Destroy(gameObject);
        }
        
    }

}
