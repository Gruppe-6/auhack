using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogChoice : MonoBehaviour
{
    private GameObject Left, Middle, Right, Question;
    [SerializeField] private TextMeshProUGUI LT, MT, RT, QT;
    public float TimeToSelect;

    private (Vector3 In, Vector3 Out) L, M, R, Q;
    private bool _in = false;
    private bool _move;
    private float fullMove = 0f, scale = 2.5f;
    public byte Answer;

    
    // Start is called before the first frame update
    void Start()
    {
        Left = transform.Find("LeftDialog").gameObject;
        Middle = transform.Find("MiddleDialog").gameObject;
        Right = transform.Find("RightDialog").gameObject;
        
        Left.GetComponent<ControllerInteract>().Timer = TimeToSelect;
        Middle.GetComponent<ControllerInteract>().Timer = TimeToSelect;
        Right.GetComponent<ControllerInteract>().Timer = TimeToSelect;
        Question = transform.Find("Question").gameObject;

        /*LT = Left.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        MT = Middle.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        RT = Right.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        QT = Question.GetComponent<TextMeshProUGUI>();*/

        L = (Left.transform.position, Left.transform.position + new Vector3(-200, -200, -400));
        M = (Middle.transform.position, Middle.transform.position + new Vector3(0, -200, -400));
        R = (Right.transform.position, Right.transform.position + new Vector3(200, -200, -400));
        Q = (Question.transform.position, Question.transform.position + new Vector3(0, 400, -700));

        Left.transform.position = L.Out;
        Middle.transform.position = M.Out;
        Right.transform.position = R.Out;
        Question.transform.position = Q.Out;
        _in = false;
        //_move = true;
        //StartCoroutine(Test());
    }

    // Update is called once per frame
    void Update()
    {
        if (_move)
        {
            SetElements(true);
            fullMove += Time.deltaTime;
            if (_in)
            {
                Left.transform.position = Vector3.Lerp(L.In, L.Out, (fullMove * scale) < 1f ? fullMove * scale : 1);
                Middle.transform.position = Vector3.Lerp(M.In, M.Out, (fullMove * scale) < 1f ? fullMove * scale : 1);
                Right.transform.position = Vector3.Lerp(R.In, R.Out, (fullMove * scale) < 1f ? fullMove * scale : 1);
                Question.transform.position = Vector3.Lerp(Q.In, Q.Out, (fullMove * scale) < 1f ? fullMove * scale : 1);
                
                //scale += 0.05f;
                scale += Time.deltaTime;
            }
            else if (!_in)
            {
                Left.transform.position = Vector3.Lerp(L.Out, L.In, (fullMove * scale) < 1f ? fullMove * scale : 1);
                Middle.transform.position = Vector3.Lerp(M.Out, M.In, (fullMove * scale) < 1f ? fullMove * scale : 1);
                Right.transform.position = Vector3.Lerp(R.Out, R.In, (fullMove * scale) < 1f ? fullMove * scale : 1);
                Question.transform.position = Vector3.Lerp(Q.Out, Q.In, (fullMove * scale) < 1f ? fullMove * scale : 1);

                //scale -= 0.05f;
                scale -= Time.deltaTime;
            }

            if (fullMove >= 1)
            {
                Debug.Log($"Moved " + (_in ? "out" : "in"));
                fullMove = 0;
                _move = false;
                _in = !_in;
                SetElements(_in);
            }
        }
    }

    private void SetElements(bool state)
    {
        Left.SetActive(state);
        Middle.SetActive(state);
        Right.SetActive(state);
        Question.SetActive(state);
    }

    public void AskQuestion(string q, string op1, string op2, string op3, Action<int> callback)
    {
        LT.text = op1;
        MT.text = op2;
        RT.text = op3;
        QT.text = q;
        _move = true;
        print(callback);
        StartCoroutine(HandleQuestion(callback));
    }

    //public void AskQuestion(string[] lines) => AskQuestion(lines[0], lines[1], lines[2], lines[3]);

    IEnumerator HandleQuestion(Action<int> onDecision)
    {
        Answer = 0;
        yield return WaitUntilTrue(() =>
        {
            if (Left.GetComponent<ControllerInteract>().Chosen)
            {
                onDecision(1);
                return 1;
            }
            else if (Middle.GetComponent<ControllerInteract>().Chosen)
            {
                onDecision(2);
                return 2;
            }
            else if (Right.GetComponent<ControllerInteract>().Chosen)
            {
                onDecision(2);
                return 3;
            }
            else
                return 0;
        });
    }
    IEnumerator WaitUntilTrue(Func<byte> checkMethod)
    {
        byte val = checkMethod();
        while (val == 0)
        {
            val = checkMethod();
            yield return null;
        }
        Answer = val;
        _move = true;
        
        Debug.Log(Answer);
    }

    /*IEnumerator Test()
    {
        yield return new WaitForSeconds(5);
        AskQuestion("Er du stray?", "Ja", "Måske", "Nej");
        yield return 0;
    }*/
}
