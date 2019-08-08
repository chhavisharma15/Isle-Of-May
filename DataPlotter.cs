using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

namespace MagicLeap {
    public class DataPlotter : MonoBehaviour
    {
        public string inputfile;

        private List<Dictionary<string, object>> pointList;

        public int columnX = 0;
        public int columnY = 1;
        public int columnZ = 2;
        public int names = 3;

        public string xName;
        public string yName;
        public string zName;
        public string species;

        public float plotScale = 10;

        private bool lmao = false;

        public GameObject PointPrefab;

        public GameObject PointHolder;

        void OnEnable()
        {
            if (lmao == false)
            {
                pointList = CSVReader.Read(inputfile); 

                Debug.Log("This is pointlist: " + pointList);

                List<string> columnList = new List<string>(pointList[1].Keys); 

                Debug.Log("There are " + columnList.Count + " columns in the CSV"); 

                xName = columnList[columnX];
                yName = columnList[columnY];
                zName = columnList[columnZ];
                species = columnList[names];

                float xMax = FindMaxValue(xName);
                float yMax = FindMaxValue(yName);
                float zMax = FindMaxValue(zName);
                float xMin = FindMinValue(xName);
                float yMin = FindMinValue(yName);
                float zMin = FindMinValue(zName);

                for (var i = 0; i < pointList.Count; i++)
                {
                    float x = (System.Convert.ToSingle(pointList[i][xName]) - xMin) / (xMax - xMin);
                    x = x * (float)0.15;

                    float y = (System.Convert.ToSingle(pointList[i][yName]) - yMin) / (yMax - yMin);

                    y = y * (float)0.15;

                    float z = 0;

                    GameObject dataPoint = Instantiate(PointPrefab, new Vector3(x, z, y) , Quaternion.identity);

                    string dataPointName = pointList[i][xName] + " " + pointList[i][yName] + " " + pointList[i][zName];

                    dataPoint.transform.name = dataPointName; 

                    
                        if (System.Convert.ToString(pointList[i][species]) == "Ulva")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Patella vulgata")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Alaria esculenta")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1.0f);
                        }

                        else if (System.Convert.ToString(pointList[i][species]) == "Obelia geniculata")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(211, 218, 0, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Crossaster papposus")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(132, 213, 110, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Ceramium shuttleworthianum")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(0, 0, 65, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Vertebrata lanosa")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(12, 0, 113, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Laminaria digitata")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(190, 118, 123, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Laminaria hyperborea")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(100, 0, 0, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Echinus esculentus")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(0, 143, 123, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Cancer pagurus")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(231, 0, 132, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Urticina felina")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(256, 11, 0, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Asterias rubens")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(0, 12, 0, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Ophiothrix fragilis")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(142, 12, 111, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Spirobranchus")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(231, 114, 87, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Corallina officinalis")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(1, 0, 211, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Corallinaceae")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(42, 212, 121, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Clavelina lepadiformis")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(14, 1, 1, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Alcyonium digitatum")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(191, 178, 161, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Parasmittina trispinosa")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(149, 0, 120, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Rhodophyta")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(142, 12, 111, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Pagurus bernhardus")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(98, 112, 101, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Chromista")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(162, 129, 27, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Gibbula cineraria")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(179, 212, 245, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Mastocarpus stellatus")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(198, 112, 82, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Semibalanus balanoides")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(256, 12, 111, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Chromista")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(123, 112, 191, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Cladophora rupestris")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(42, 182, 256, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Heteranomia squamula")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(140, 152, 211, 1.0f);
                        }
                        else if (System.Convert.ToString(pointList[i][species]) == "Pandalus montagui")
                        {
                            dataPoint.GetComponent<Renderer>().material.color = new Color(142, 19, 11, 1.0f);
                        }
                }

                lmao = true;
            }

        }


        private float FindMaxValue(string columnName)
        {
            //set initial value to first value
            float maxValue = Convert.ToSingle(pointList[0][columnName]);

            //Loop through Dictionary, overwrite existing maxValue if new value is larger
            for (var i = 0; i < pointList.Count; i++)
            {
                if (maxValue < Convert.ToSingle(pointList[i][columnName]))
                    maxValue = Convert.ToSingle(pointList[i][columnName]);
            }
            return maxValue;
        }

        private float FindMinValue(string columnName)
        {

            float minValue = Convert.ToSingle(pointList[0][columnName]);

            for (var i = 0; i < pointList.Count; i++)
            {
                if (Convert.ToSingle(pointList[i][columnName]) < minValue)
                    minValue = Convert.ToSingle(pointList[i][columnName]);
            }

            return minValue;
        }

        
    }
}