using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBox : MonoBehaviour
{
    private int questionIndex;
    private bool showQuestionPopup;
    public GameObject panel;
    public Text questionText;
    // Start is called before the first frame update
    void Start()
    {
        questionIndex = 1;
        showQuestionPopup = false;
        panel.SetActive(false);
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://mathquizrunner-f65ac.firebaseio.com/"); //set editor ก่อนจะเรียกใช้ realtime database
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference; //อ้างอิงไปถึง root ของ database
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        panel.SetActive(true);
        getQuestion();
        StartCoroutine(TimeLimit());
    }

    IEnumerator TimeLimit()
    {
        yield return new WaitForSeconds(5); //แสดงคำถามค้างไว้ 5 วินาที
        showQuestionPopup = false;
        questionIndex++;
    }

    public void getQuestion()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference("Exercises").Child("ex1").Child("Questions").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log("Error !!");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                questionIndex++;
                print("index: " + questionIndex);
                Dictionary<string, object> question = (Dictionary<string, object>)snapshot.Child("q" + questionIndex).Value;
                print("Question " + questionIndex + ": " + question["name"]);
                questionText.text = question["name"].ToString();
            }
        });
    }
}
