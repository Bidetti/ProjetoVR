using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ProductInteractable : XRBaseInteractable
{
    [Header("Float Animation")]
    [SerializeField] float floatHeight = 0.5f;
    [SerializeField] float floatSpeed = 1f;
    
    [Header("UI")]
    [SerializeField] GameObject techSpecsUI;
    
    [Header("Rotation")]
    [SerializeField] float rotationSpeed = 50f;
    
    private Vector3 initialPosition;
    private bool isSelected = false;
    private static ProductInteractable currentlySelected;
    
    protected override void Awake()
    {
        base.Awake();
        initialPosition = transform.position;
        if (techSpecsUI != null)
            techSpecsUI.SetActive(false);
    }
    
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        
        // Desseleciona o produto anterior
        if (currentlySelected != null && currentlySelected != this)
        {
            currentlySelected.Deselect();
        }
        
        currentlySelected = this;
        isSelected = true;
        
        // Ativa UI
        if (techSpecsUI != null)
            techSpecsUI.SetActive(true);
    }
    
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        Deselect();
    }
    
    void Update()
    {
        if (isSelected)
        {
            // Animação de flutuação
            float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            
            // Rotação automática
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
    
    public void Deselect()
    {
        isSelected = false;
        transform.position = initialPosition;
        
        if (techSpecsUI != null)
            techSpecsUI.SetActive(false);
            
        if (currentlySelected == this)
            currentlySelected = null;
    }
}
