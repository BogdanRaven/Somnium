using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int curI;
    public string end;
    public string level;
    public DialogSystem d;
    void Start()
    {
        d = GetComponentInParent<DialogSystem>();
    }

    // Update is called once per frame
    public void next()
    {
        d.Next(curI,end,level);
    }
}
