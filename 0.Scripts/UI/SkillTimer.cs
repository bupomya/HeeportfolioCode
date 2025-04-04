using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTimer : MonoBehaviour
{
    [SerializeField] private Image filledImage;

    private float timerDuration;

    private bool isTimerRunning = false;

    private float timer;

    private SkillAttack skillAttack;

    private void Update()
    {
        if (isTimerRunning)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
                filledImage.fillAmount = timer / timerDuration;
            }
            else
            {
                EndTimer();
            }
        }
    }

    public void StartTimer(SkillAttack skillAttack, float timeDuration)
    {
        this.skillAttack = skillAttack;

        this.timerDuration = timeDuration;

        timer = timerDuration;
        isTimerRunning = true;
        filledImage.raycastTarget = false; // 터치 불가
    }


    public void EndTimer()
    {
        isTimerRunning = false;

        filledImage.fillAmount = 0f;
        filledImage.raycastTarget = true; // 터치 가능

        skillAttack.EndSkill();
    }
}
