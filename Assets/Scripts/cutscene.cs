using UnityEngine;

public class cutscene : MonoBehaviour
{
    [SerializeField] private GameObject scene1;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            
              
                scene1.gameObject.SetActive(false);
            
            
        }
    }
}
