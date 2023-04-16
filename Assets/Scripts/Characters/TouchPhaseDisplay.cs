using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPhaseDisplay : MonoBehaviour
{
    public Text phaseDisplayText;
    private Touch theTouch;
    private float timeTouchEnded;
    private int maximumTimeCap = 3000;
    private float startTime;
    public float elapsedTime;
    private float displayTime = 0.5f;

    public TransformCharge transformCharge;
    void Start(){
        transformCharge.SetMaxCharge(maximumTimeCap);
    }
    void Update()
    {
        if(Input.touchCount > 0){
            theTouch = Input.GetTouch(0);
            if(theTouch.phase == TouchPhase.Ended)
            {
                elapsedTime = Time.time - startTime;
                //phaseDisplayText.text = theTouch.phase.ToString() + elapsedTime;
                timeTouchEnded = Time.time;
            }else if(theTouch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
            }else if(theTouch.phase == TouchPhase.Stationary)
            {
                elapsedTime = (Time.time - startTime)*2000;
                transformCharge.SetCharge((int)elapsedTime);
            }
            else if(Time.time - timeTouchEnded > displayTime)
            {
                //phaseDisplayText.text = theTouch.phase.ToString();
                timeTouchEnded = Time.time;
            }        
        }
        else if (Time.time - timeTouchEnded > displayTime)
        {
            phaseDisplayText.text = "";
            transformCharge.SetCharge(0);
        }
}
}
