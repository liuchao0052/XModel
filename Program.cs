using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XModel.test;
using System.Collections;

namespace XModel
{
    static class Program
    {
        //static Form1 form1;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()

        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            ////int a = 53;
            ////byte[] list = BitConverter.GetBytes(a);
            //Byte[] bytes = { 0xF4 ,0x00};
            //BitArray arr = new BitArray(bytes);
            ////bool bit = arr[0];//取第一位，用bool类型表示
            //for (int i = arr.Count-1; i >=0; i--)
            //{
            //    Console.Write("{0, -3} ", arr[i]);
            //    //Console.Write(arr[i]+" ");
            //}

            //Application.Run(new Form_port());
            //Application.Run(new Form2());
            //Application.Run(new Form3());
            //Application.Run(new Form4());
            //Application.Run(new RealChart());
            //Application.Run(new Form5());
            
        }
    }
}
