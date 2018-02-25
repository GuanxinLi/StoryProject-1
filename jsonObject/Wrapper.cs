using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wrapper {

    public string version;
    public Header header;
    public Result[] results;

    public string Version
    {
        get
        {
            return version;
        }

        set
        {
            version = value;
        }
    }

    public Header Header
    {
        get
        {
            return header;
        }

        set
        {
            header = value;
        }
    }

    public Result[] Results
    {
        get
        {
            return results;
        }

        set
        {
            results = value;
        }
    }
}
