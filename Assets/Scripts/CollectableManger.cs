using UnityEngine;

public class CollectableManger : MonoBehaviour
{

    private int keyCount = 0;
    [SerializeField] private GameObject hiddenPortal;

    private void OnEnable()
    {
        Item.OnItemCollect += Item_OnItemCollect;
    }


    private void OnDisable()
    {
        Item.OnItemCollect -= Item_OnItemCollect;
    }
    private void Item_OnItemCollect(string obj)
    {
        if(obj == "Key")
        {
            keyCount++;

            if(keyCount == 3)
            {
                hiddenPortal.gameObject.SetActive(true);
            }
        }
    }
}
