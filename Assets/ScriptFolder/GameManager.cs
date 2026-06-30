using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject QuizPanel1;
    [SerializeField] private GameObject QuizPanel2;
    [SerializeField] private GameObject QuizPanel3;
    [SerializeField] private GameObject QuizPanel4;
    [SerializeField] private GameObject resultPanal;

    [SerializeField] private GameObject Objects;
    [SerializeField] private GameObject snapZones;

    private int placedObjectCount = 0;

    private void Start()
    {
        QuizPanel1.SetActive(false);
        QuizPanel2.SetActive(false);
        QuizPanel3.SetActive(false);
        QuizPanel4.SetActive(false);
        resultPanal.SetActive(false);
    }

    public void ObjectPlaced()
    {
        placedObjectCount++;

        if (placedObjectCount == 5)
        { 
            QuizPanel1.SetActive(true);
            Invoke("ObSn", 2f);
        }
    }
    void ObSn()
    {
        Objects.SetActive(false);
        snapZones.SetActive(false);
    }
}

