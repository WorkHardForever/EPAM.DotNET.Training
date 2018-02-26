using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SEHExceptionHandling
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Debug.WriteLine("method main works");
                FormatDataForDisplay();
            }
            catch (Exception e)
            {
                Debug.WriteLine("method main catch block");
                Debug.WriteLine("1. " + e.Message + "\n");//Текст, описывающий условие ошибки, в нашем случае это файл и полный путь где должен был находиться файл не найден 
                Debug.WriteLine("2. " + e.Source + "\n");//Имя приложения или объекта, вызвавшего исключение, в нашем случае, т.к. ошибка была переброшена с помощью throw, то FunctionA
                Debug.WriteLine("3. " + e.TargetSite + "\n");//описывает  метод,  возбудивший исключение 
                Debug.WriteLine("4. " + e.StackTrace + "\n");
            }
        }

        #region Function A

        static void FormatDataForDisplay()
        {
            try
            {
                Debug.WriteLine("method A (FormatDataForDisplay) works");
                ProcessData();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("method A (FormatDataForDisplay) catch block");
                Debug.WriteLine(ex.StackTrace);
                throw ex; //CLR считает, что исключение возникло здесь
            }
            finally
            {
                Debug.WriteLine("method A (FormatDataForDisplay) finally block");
            }
        }
        #endregion

        #region Function B
        static void ProcessData()
        {
            try
            {
                Debug.WriteLine("method B (ProcessData) works");
                GetFile();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("method B (ProcessData) catch block");
                Debug.WriteLine(ex.StackTrace);
                throw; //CLR не меняет информацию о начальной точке исключения
            }
            finally
            {
                Debug.WriteLine("method B (ProcessData) finally block");
            }
        }
        #endregion

        #region Function C
        static void GetFile()
        {
            Debug.WriteLine("method C (GetFile) works");
            //try
          //  {
                File.Open("text.txt", FileMode.Open);
           // }
            //catch (IOException ex)
            //{
            //    throw new IOException("Data File Data.txt was not found");
                
            //}
           
        }
        #endregion
    }
}