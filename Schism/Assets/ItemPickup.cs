using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject itemObject = transform.gameObject; // Get the parent game object

            Item item = itemObject.GetComponent<Item>();

            // Add the item to the inventory
            InventoryManager.instance.AddItem(itemObject);

            // Disable the item game object
            item.ResetItem();
        }
    }
}
