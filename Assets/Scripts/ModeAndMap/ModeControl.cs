using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Modes
{
    Normal,
    Lost,
    Found
}

public class ModeControl : MonoBehaviour
{
    public static ModeControl Instance { get; set; }


    [SerializeField] public Modes currentMode = Modes.Normal;

    [SerializeField] private KeyCode lostModeKeyCode = KeyCode.Q;
    [SerializeField] private KeyCode foundModeKeyCode = KeyCode.E;

    [SerializeField] private float modeLastingTime = 5f; // 持續時間
    [SerializeField] private float switchModeCDTime = 2f;
    [SerializeField] private bool inCD = false;

   /**** Subject (Observer Pattern?) *****/
   public List<ModeObserver> modeObservers = new List<ModeObserver>();
    public void RegisterObserver(ModeObserver observer)
    {
        modeObservers.Add(observer);
    }
    public void Notify ()
    {
        foreach(var observer in modeObservers)
        {
            if(observer!=null) //背Destroy掉沒解註冊的Observer就不理它
            {
                observer.OnNotify(currentMode);
            }

        }
    }
    /*************************************/


    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Start()
    {
        yield return 0; //Wait for one frame to get all observers
        Notify(); 
    }

    // Update is called once per frame
    void Update()
    {
        ScanKey();
    }

    private void ScanKey()
    {
        if (currentMode != Modes.Normal || inCD)
        {
            return;
        }

        if (Input.GetKeyDown(lostModeKeyCode))
        {
            //Debug.Log($"Lost Mode Activated");
            currentMode = Modes.Lost;
            StartCoroutine(Timer(modeLastingTime, switchModeCDTime));
           
            Notify();  //Send Mode Update to Observers
        }
        else if (Input.GetKeyDown(foundModeKeyCode))
        {
            //Debug.Log($"Found Mode Activated");
            currentMode = Modes.Found;
            StartCoroutine(Timer(modeLastingTime, switchModeCDTime));
            Notify();  //Send Mode Update to Observers
        }

    }

    IEnumerator Timer(float lastingTime, float CDTime)
    {
        inCD = true;

        yield return new WaitForSeconds(lastingTime);

        //Debug.Log($"Mode Switched Backed to Normal");
        currentMode = Modes.Normal;
        Notify();

        yield return new WaitForSeconds(CDTime);

        //Debug.Log($"CD Time End, Can Switch Mode");
        inCD = false;

    }


}
