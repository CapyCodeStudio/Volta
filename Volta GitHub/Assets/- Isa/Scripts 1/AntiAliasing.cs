using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAliasing : MonoBehaviour
{
        private bool highQualityAA = true; // Defina como true para começar com alta qualidade de antialiasing
        //public GameObject button; // Arraste o botão UI para este campo no Inspector

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
            int qualityLevel = highQualityAA ? 0 : 4; // Defina os índices de qualidade para as configurações desejadas
            QualitySettings.SetQualityLevel(qualityLevel);
        }
}


