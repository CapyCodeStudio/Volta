using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAliasing : MonoBehaviour
{
        private bool highQualityAA = true; // Defina como true para come�ar com alta qualidade de antialiasing
        //public GameObject button; // Arraste o bot�o UI para este campo no Inspector

        private void Start()
        {
            UpdateAntialiasingSettings();
        }

        public void ToggleAntialiasing()
        {
            highQualityAA = !highQualityAA;
            UpdateAntialiasingSettings();
        }

        private void UpdateAntialiasingSettings()
        {
            int qualityLevel = highQualityAA ? 0 : 1; // Defina os �ndices de qualidade para as configura��es desejadas
            QualitySettings.SetQualityLevel(qualityLevel);
        }
}


