using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Result {

    public string scenario;
    public string name;
    public string lexical;
    public string confidence;
    public Properties properties;

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

    public string Confidence
    {
        get
        {
            return confidence;
        }

        set
        {
            confidence = value;
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
