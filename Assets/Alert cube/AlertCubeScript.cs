using UnityEngine;
using System;

public class AlertCubeScript : MonoBehaviour
{
    public TextAsset ExcelFile;
    public int cycleSensor;
    private int sensor = 1;
    private int pickSensor;
    private float testAlert;
    private float[] dataArray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
        var mat = GetComponent<Renderer>().material;
        mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.0f);
    }

    void Update()
    {
        //testAlert = ReadCSV();
        //testAlert = ReadCSV2(pickSensor);
        testAlert = ReadCSV3(cycleSensor);
        cycleSensor = 0;
        if (testAlert > 1)
        {
            //color red
            var mat = GetComponent<Renderer>().material;
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.5f);
        }
        else
        {
            //transparent
            var mat = GetComponent<Renderer>().material;
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.0f);

        }
    }
    private float ReadCSV()
    {
        string[] data = ExcelFile.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int dataLenght = data.Length;
        float lastValue = float.Parse(data[dataLenght-2]);
        return lastValue;
    }

    private float ReadCSV2(int sensor)
    {
        string[] data = ExcelFile.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int dataLenght = data.Length;
        if (sensor <= dataLenght)
        {
            float sensorValue = float.Parse(data[sensor-1]);
            return sensorValue;
        }
        else
        {
            return 0;
        }
    }

    private float ReadCSV3(int cycle)
    {
        string[] data = ExcelFile.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int dataLenght = data.Length;
        //Debug.Log(sensor.ToString());
        if (sensor < (dataLenght))
        {
            float sensorValue = float.Parse(data[sensor-1]);
            if (cycle == 1)
            {
                sensor = sensor + 1;
            }
            return sensorValue;
        }
        else
        {
            sensor = 1;
            float sensorValue = float.Parse(data[sensor-1]);
            return sensorValue;
        }
    }
}
