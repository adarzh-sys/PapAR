using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class AlertCubeScript : MonoBehaviour
{
    public TextAsset ExcelFile;
    public GameObject alertUI;
    public float threshold = 1f;
    public float cycleTime = 2f;
    public Toggle alertToggle; // 👈 ADD THIS

    private List<SensorData> sensorDataList = new List<SensorData>();
    private float timer = 0f;
    private int currentSensorIndex = 0;

    private void Start()
    {
        ParseCSV();
    }

    private void Update()
    {
        if (sensorDataList.Count == 0)
            return;

        timer += Time.deltaTime;
        if (timer >= cycleTime)
        {
            timer = 0f;
            CycleNextSensor();
        }
    }

    private void ParseCSV()
    {
        sensorDataList.Clear();

        if (ExcelFile == null)
            return;

        string[] lines = ExcelFile.text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length > 1 && float.TryParse(parts[1], out float value))
            {
                sensorDataList.Add(new SensorData
                {
                    name = parts[0],
                    value = value
                });
            }
        }
    }

    private void CycleNextSensor()
    {
        if (sensorDataList.Count == 0)
            return;

        SensorData currentSensor = sensorDataList[currentSensorIndex];
        Debug.Log($"Sensor: {currentSensor.name}, Value: {currentSensor.value}");

        var mat = GetComponent<Renderer>().material;

        // 👇 Check if toggle is ON
        if (alertToggle != null && alertToggle.isOn)
        {
            if (currentSensor.value > threshold)
            {
                mat.color = Color.red;
                if (alertUI != null)
                    alertUI.SetActive(true);
            }
            else
            {
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.1f);
                if (alertUI != null)
                    alertUI.SetActive(false);
            }
        }
        else
        {
            // If toggle is OFF → always transparent + hide UI
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.1f);
            if (alertUI != null)
                alertUI.SetActive(false);
        }

        currentSensorIndex = (currentSensorIndex + 1) % sensorDataList.Count;
    }

    [Serializable]
    private class SensorData
    {
        public string name;
        public float value;
    }
}