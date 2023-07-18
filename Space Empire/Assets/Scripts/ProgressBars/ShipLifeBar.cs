using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ShipLifeBar : MonoBehaviour
{
    public static ShipLifeBar Instance;
    public int minimum;
    public int maximum;
    public int current;
    public Image mask;
    
    void Awake() {
        Instance = this;
    }

    void Start()
    {
        minimum = 0;
        maximum = 10;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill(){
        float fillAmount = (float)(current - minimum) / (float)(maximum - minimum);
        mask.fillAmount = fillAmount;
    }

    public void ShipLifeEffect(int i){
        current = i;
    }
    
}
