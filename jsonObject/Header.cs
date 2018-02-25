using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Header {

    public string status;
    public string scenario;
    public string name;
    public string lexical;
    public Properties properties;

    public string Status
    {
        get
        {
            return status;
        }

        set
        {
            status = value;
        }
    }

    public string Scenario
    {
        get
        {
            return scenario;
        }

        set
        {
            scenario = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Lexical
    {
        get
        {
            return lexical;
        }

        set
        {
            lexical = value;
        }
    }

    public Properties Properties
    {
        get
        {
            return properties;
        }

        set
        {
            properties = value;
        }
    }
}
