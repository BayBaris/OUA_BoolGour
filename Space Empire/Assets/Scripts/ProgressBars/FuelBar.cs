using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public static FuelBar Instance;
    public int minimum;
    public int maximum;
    public Image mask;
    public static float fuelAmount;
    
    void Awake() {
        Instance = this;
    }

    void Start()
    {
        minimum = 0;
        maximum = 100;
        InvokeRepeating("FuelControl", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill(){
        float fillAmount = (float)(fuelAmount - minimum) / (float)(maximum - minimum);
        mask.fillAmount = fillAmount;
    }

    public void FuelBarEffect(float i){
        fuelAmount = i;
    }

    void FuelDone()
    {
        Debug.Log("Yakıt tükendi!");
    }
    
    void FuelControl(){
        Debug.Log("fuel amount"+ fuelAmount);
        RealmController.Instance.FuelBar(fuelAmount);
        if(fuelAmount <=0)
        {
            FuelDone();
        }else
        {
            fuelAmount -= 0.02f;
        }
    }
}
