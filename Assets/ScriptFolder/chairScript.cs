using NUnit.Framework.Constraints;
using Unity.GraphToolkit.Editor;
using UnityEngine;
using UnityEngine.InputSystem;

public class chairScript : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject objectUI;

    [Header("Color")]
    [SerializeField] private Color selectedColor = Color.black;

    [Header("GameManager")]
    [SerializeField] private GameManager gameManager;

    [SerializeField]private Renderer objectRenderer;
    [SerializeField]private Renderer objectRenderer1;
    private AudioSource audioSource;
    private Color originalColor;

    [SerializeField] private AudioClip Correctclip;
    [SerializeField] private AudioClip InCorrectclip;

    // Drag Variables
    private Vector3 offset;
    private float zDistance;

    private Vector3 OGchairPosition;
    private Vector3 snapZonePosition;
    private bool isCorrectSlotChair = false;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalColor = objectRenderer.material.color;
        originalColor = objectRenderer1.material.color;
        if (objectUI != null)
        {
            objectUI.SetActive(false);
        }
        objectRenderer.material.color = selectedColor;
        objectRenderer1.material.color = selectedColor;
        OGchairPosition = transform.position;
    }



    private void OnMouseEnter()
    {
        if (objectUI != null)
            objectUI.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (objectUI != null)
            objectUI.SetActive(false);
    }


    private void OnMouseDown()
    {
        // Change Color
        objectRenderer.material.color = originalColor;
        objectRenderer1.material.color = originalColor;

        // Play Audio
        if (audioSource.clip != null)
            audioSource.Play();

        // Prepare Drag
        zDistance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector2 mousePos = Mouse.current.position.ReadValue();

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(mousePos.x, mousePos.y, zDistance));

        offset = transform.position - mouseWorldPos;
    }



    private void OnMouseDrag()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(mousePos.x, mousePos.y, zDistance));

        transform.position = mouseWorldPos + offset;
    }


    private void OnMouseUp()
    {
        if (isCorrectSlotChair == false)
        {
            transform.position = OGchairPosition;
            audioSource.PlayOneShot(InCorrectclip);
        }
        else
        {
            transform.position = snapZonePosition;
            gameManager.ObjectPlaced();
            audioSource.PlayOneShot(Correctclip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChairTag"))
        {
            snapZonePosition = other.gameObject.transform.position;
            isCorrectSlotChair = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ChairTag"))
        {
            snapZonePosition = other.gameObject.transform.position;
            isCorrectSlotChair = false;
        }
    }
}
