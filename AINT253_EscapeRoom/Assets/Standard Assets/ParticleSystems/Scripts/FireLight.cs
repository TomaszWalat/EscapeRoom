using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Effects
{
    public class FireLight : MonoBehaviour
    {
        private float m_Rnd;
        [SerializeField]
        private bool m_Burning = false;
        //[SerializeField]
        //private float minIntensity = 1.0f;
        [SerializeField]
        private float maxIntensity = 1.0f;
        //[SerializeField]
        //private int counter = 1;
        private Light m_Light;


        private void Start()
        {
            m_Rnd = Random.value*100;
            m_Light = GetComponent<Light>();
            //m_Light.GetComponent<Light>().enabled = m_Burning;
        }


        private void FixedUpdate()
        {
            if (m_Burning)
            {
                m_Light.intensity = 1 + Mathf.PingPong(Time.time, maxIntensity) + Mathf.PerlinNoise(m_Rnd + Time.time * 1, m_Rnd + Time.time * 1); // Mathf.PerlinNoise();//m_Rnd + Time.time * 1, m_Rnd + Time.time * 1) / Mathf.PerlinNoise(m_Rnd + Time.time * 2, m_Rnd + Time.time * 2);//Random.Range(minIntensity, maxIntensity) / Random.Range(minIntensity, maxIntensity);//2 * Mathf.PerlinNoise(m_Rnd + 1 + Time.time * 1, m_Rnd + 2 + Time.time*2);
                float x = Mathf.PerlinNoise(m_Rnd + 0 + Time.time*2, m_Rnd + 1 + Time.time*2) - 0.5f;
                float y = Mathf.PerlinNoise(m_Rnd + 2 + Time.time*2, m_Rnd + 3 + Time.time*2) - 0.5f;
                float z = Mathf.PerlinNoise(m_Rnd + 4 + Time.time*2, m_Rnd + 5 + Time.time*2) - 0.5f;
                transform.localPosition = Vector3.up + new Vector3(x, y, z)*1;

                //counter++;
                //if (counter > 3)
                //{
                //    counter = 1;
                //}
            }
        }

        //public void Light()
        //{
        //    m_Burning = true;
        //    m_Light.enabled = true;
        //    m_Light.GetComponent<Light>().enabled = m_Burning;
        //}

        //public void Extinguish()
        //{
        //    m_Burning = false;
        //    m_Light.enabled = false;
        //    m_Light.GetComponent<Light>().enabled = m_Burning;
        //}
    }
}
