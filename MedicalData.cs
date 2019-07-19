using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModel
{
    class MedicalData
    {
    }
    //血压数据类型
    public class BloodPressureDataType
    {
        Int16 highBP; //高压

        public Int16 HighBP
        {
            get { return highBP; }
            set { highBP = value; }
        }



        Int16 lowBP;  //低压

        public Int16 LowBP
        {
            get { return lowBP; }
            set { lowBP = value; }
        }

      
    }

    //体温数据类型
    public class TemperatureDataType
    {
        Byte temperatureInteger; //体温整数部分
        Byte temperatureDecimal; //体温小数部分 

        public Byte TemperatureInteger
        {
            get { return temperatureInteger; }
            set { temperatureInteger = value; }
        }


        public Byte TemperatureDecimal
        {
            get { return temperatureDecimal; }
            set { temperatureDecimal = value; }
        }


    }

    //心率数据类型
    public class HeartRateDataType
    {
        Int16 heartRate; //心率

        public Int16 HeartRate
        {
            get { return heartRate; }
            set { heartRate = value; }
        }      
    }
}
