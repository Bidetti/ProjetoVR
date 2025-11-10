using UnityEngine;
using TMPro;

public class TechSpecsUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI productName;
    [SerializeField] TextMeshProUGUI specifications;
    
    public void SetSpecs(string name, string specs)
    {
        if (productName != null)
            productName.text = name;
        if (specifications != null)
            specifications.text = specs;
    }
    
    void Update()
    {

    }
}
