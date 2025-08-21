using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindFirstObjectByType<UIManager>();
            }

            return m_instance;
        }
    }

    UIManager m_instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
