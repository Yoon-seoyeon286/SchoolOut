using UnityEngine;

public class Flash : MonoBehaviour, IItem
{
    public Light spotLight;


    float durationTime = 30f;

    void Update()
    {

    }


    public void UseItem(GameObject target)
    {
        Battery battery = target.GetComponent<Battery>();

        if (battery != null && durationTime <=30f )
        {
            spotLight.gameObject.SetActive(true);
        }
    }
}
