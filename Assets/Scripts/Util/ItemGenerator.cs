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
            case (int)ItemType.CharacterSpeedUp: 
                newItem = Instantiate(CheesePrefab);
                SetItemPosition(newItem);
                break;
            case (int)ItemType.HpRecovery: 
                newItem = Instantiate(ChickenPrefab);
                SetItemPosition(newItem);
                break;
            case (int)ItemType.CharacterInvincible: 
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
        float y = Random.Range(4.0f, 5.0f);
        itemObj.transform.position = new Vector3(x, y, 0);
    }
}