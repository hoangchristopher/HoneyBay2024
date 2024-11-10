using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class InstructionDisplay : MonoBehaviour
{
    public TextMeshProUGUI instructionText; 

    private string[] instructions = {
        "Hi, you will soon begin the game.",
        "Instructions for each step will be provided along the way.",
        "Press the button to start."
    };

    void Start()
    {
        StartCoroutine(DisplayInstructions());
    }

    IEnumerator DisplayInstructions()
    {
        for (int i = 0; i < instructions.Length; i++)
        {
            instructionText.text = instructions[i]; // 문장 표시
            yield return new WaitForSeconds(3); // 3초 대기
        }

        instructionText.text = ""; // 마지막 문장 후 텍스트 비우기
    }
}
