using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Properties{

    public string requestid;
    public string HIGHCONF;

    public string Requestid
    {
        get
        {
            return requestid;
        }

        set
        {
            requestid = value;
        }
    }

    public string HIGHCONF1
    {
        get
        {
            return HIGHCONF;
        }

        set
        {
            HIGHCONF = value;
        }
    }
}
