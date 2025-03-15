using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public static readonly float ITEMDELAY = 15.0f;
    private float delay = ITEMDELAY;
    private int ItemTypeCount;
    public GameObject CheesePrefab;
    public GameObject ChickenPrefab;
    public GameObject FishPrefab;

    private void Awake()
    {
        ItemTypeCount = System.Enum.GetValues(typeof(ItemType)).Length;
    }

    private void Generate()
    {
        int itemType = Random.Range(0, ItemTypeCount);

        GameObject newItem;
        switch (itemType)
        {
            case (int)ItemType.Cheese: 
                newItem = Instantiate(CheesePrefab);
                SetItemPosition(newItem);
                break;
            case (int)ItemType.Chicken: 
                newItem = Instantiate(ChickenPrefab);
                SetItemPosition(newItem);
                break;
            case (int)ItemType.Fish: 
                newItem = Instantiate(FishPrefab);
                SetItemPosition(newItem);
                break;
        }
    }

    private void Update()
    {
        if (delay > 0) delay -= Time.deltaTime;
        else
        {
            delay = ITEMDELAY;
            Generate();
        }
    }

    private void SetItemPosition(GameObject itemObj)
    {
        float x = Random.Range(-4.5f, 4.5f);
        itemObj.transform.position = new Vector3(x, 5.0f, 0);
    }
}