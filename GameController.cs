
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int distancemoved;
    public Text distanceShow;
    public Transform playerTranform;
    public GameObject questionBox;
    private int questionBoxPos;

    // Start is called before the first frame update
    void Start()
    {
        questionBoxPos = 50;
        distancemoved = 1;
        generateQuestionBox();
    }

    // Update is called once per frame
    void Update()
    {
        distancemoved = (int)playerTranform.position.z; //ให้ค่า distance มีค่าเท่ากับค่าตำแหน่งของ object player ในแนวแกน Z
        distanceShow.text = distancemoved.ToString();

        /*if (distancemoved % 100 == 0 && distancemoved != 0) //แสดงคำถามทุกๆระยะทาง 100 เมตร
        {
            showQuestionPopup = true;
            generateQuestion();
        }
        if (showQuestionPopup)
        {
            panel.SetActive(true);
            getQuestion();
            showQuestionPopup = false;
            //StartCoroutine(TimeLimit());
        }
        else
        {
            panel.SetActive(false);
        }*/
    }

    void generateQuestionBox()
    {
        Vector3 genPosition = new Vector3(0, 2, questionBoxPos);
        Instantiate(questionBox, genPosition, questionBox.transform.rotation);
        questionBoxPos += 50;
    }
}
