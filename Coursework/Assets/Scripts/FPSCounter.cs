using System;
using UnityEngine;
using UnityEngine.UI;

/*This script calculates and displays the FPS rate. It is assigned
 * to the Unity text object FPS Counter. This script came from 
 * the standard assets library for Unity. It calculates the average
 * FPS by dividing the number of frames in a period by the time taken
 * to draw them*/

namespace UnityStandardAssets.Utility
{
    [RequireComponent(typeof (Text))]
    public class FPSCounter : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        const string display = "{0} FPS";
        private Text m_Text;


        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
            m_Text = GetComponent<Text>();
        }


        private void Update()
        {
            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                m_Text.text = string.Format(display, m_CurrentFps);
            }
        }
    }
}
