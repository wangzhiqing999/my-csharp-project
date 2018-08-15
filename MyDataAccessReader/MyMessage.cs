using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MyDataAccessReader
{
    class MyMessage
    {


        /// <summary> 
        /// 成功 
        /// </summary> 
        /// <param name="message"></param> 
        public static void Success(string message)
        {
            MessageBox.Show(message, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        /// <summary> 
        /// 失败 
        /// </summary> 
        /// <param name="message"></param> 
        public static void Fail(string message)
        {
            MessageBox.Show(message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }






        /// <summary> 
        /// 警告. 
        /// </summary> 
        /// <param name="message"></param> 
        public static void Warn(string message)
        {
            MessageBox.Show(message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }






        /// <summary> 
        /// 确认. 
        /// </summary> 
        /// <param name="message"></param> 
        /// <returns></returns> 
        public static bool Makesure(string message)
        {
            DialogResult result = MessageBox.Show(message, "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            return result == DialogResult.OK;
        } 
 
 


    }
}
