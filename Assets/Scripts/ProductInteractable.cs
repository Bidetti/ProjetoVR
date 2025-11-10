using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ProductInteractable : MonoBehaviour
{
    [Header("Float Animation")]
    [SerializeField] float floatHeight = 1f;
    [SerializeField] float floatSpeed = 1f;
    
    [Header("UI")]
    [SerializeField] GameObject techSpecsUI;
    
    [Header("Rotation")]
    [SerializeField] float rotationSpeed = 50f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isRotated => initialRotation.eulerAngles.x == 90f;
    private bool isSelected = false;
    private static ProductInteractable currentlySelected;
    private XRGrabInteractable grabInteractable;
    private float floatTimer = 0f;
    
    void Awake()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        
        // Pega ou adiciona o XRGrabInteractable
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            grabInteractable = gameObject.AddComponent<XRGrabInteractable>();
        }
        
        // Configura para não ser movido fisicamente
        grabInteractable.movementType = XRBaseInteractable.MovementType.Kinematic;
        grabInteractable.throwOnDetach = false;
        
        // Registra eventos
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
        grabInteractable.selectExited.AddListener(OnSelectExited);
        
        if (techSpecsUI != null)
            techSpecsUI.SetActive(false);
    }
    
    void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Desseleciona o produto anterior
        if (currentlySelected != null && currentlySelected != this)
        {
            currentlySelected.Deselect();
        }
        
        currentlySelected = this;
        isSelected = true;
        floatTimer = 0f; // Reseta o timer da animação
        
        // Ativa UI
        if (techSpecsUI != null)
            techSpecsUI.SetActive(true);
    }
    
    void OnSelectExited(SelectExitEventArgs args)
    {
        // Não desseleciona automaticamente - mantém selecionado até clicar em outro
        // Deselect();
    }
    
    void Update()
    {
        if (isSelected)
        {
            floatTimer += Time.deltaTime; // Incrementa o timer local

            // Animação de flutuação
            float newY = initialPosition.y + (-Mathf.Cos(floatTimer * floatSpeed) + 1) / 2 * floatHeight;
            transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
            
            // Rotação automática
            if (isRotated)
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
        }
    }
    
    public void Deselect()
    {
        isSelected = false;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        
        if (techSpecsUI != null)
            techSpecsUI.SetActive(false);
            
        if (currentlySelected == this)
            currentlySelected = null;
    }
    
    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnSelectEntered);
            grabInteractable.selectExited.RemoveListener(OnSelectExited);
        }
    }
}
