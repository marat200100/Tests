using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tests.Models
{
    public class Test
    {
        public int GetByInterval(int value, int num1, int num2, int num3, int num4)
        {
            if (value >= num2 && value <= num3)
            {
                return 0;
            }
            else if ((value >= num1 && value < num2) || (value > num3 && value <= num4))
            {
                return 1;
            }
            else return 2;
        }

        public int Vision(double value)
        {
            return value < 1 ? 2 : 0; 
        }

        public int Smoking(string value)
        {
            if (value.ToLower().IndexOf("курение") != -1)
            {
                return 2;
            }
            else return 0;
        }

        public int Therapist(string values, string db)
        {
            int count = Search(values, db);
            return count <= 2 ? 0 : count == 3 ? 1 : 2;
        }

        public int Psychiatrist(string values, string db)
        {
            int count = Search(values, db);
            return count == 0 ? 0 : count == 1 ? 1 : 2;
        }

        public int Test1(int weight, bool smoking, string values)
        {
            if (!smoking && (weight > 110 && weight <= 120))
            {
                if ((values.ToLower().IndexOf("простуда") != -1) || (values.ToLower().IndexOf("вирусы") != -1))
                {
                    return 1;
                }
                else return 0;
            }
            else if (smoking && (weight > 120 || weight < 60))
            {
                if ((values.ToLower().IndexOf("простуда") != -1) || (values.ToLower().IndexOf("вирусы") != -1))
                {
                    return 2;
                }
                else return 0;
            }
            else return 0;
        }

        public int Test2(string name, int age)
        {
            //Странный тест
            //if (name.Substring(0, 1).ToUpper() == "П")
            //{
            //    return 0;
            //}
            //else if ((name.Substring(0, 1).ToUpper() != "П") && (age > 68))
            //{
            //    return 1;
            //}
            //else return 2;
            return 0;
        }

        public int Test3(string values, int growth)
        {
            if ((values.ToLower().IndexOf("насморк") != -1) && (growth % 3 == 0))
            {
                return 2;
            }
            else if ((values.ToLower().IndexOf("насморк") == -1) && (growth % 2 == 0))
            {
                return 0;
            }
            else return 1;
        }

        public int Search(string values, string db)
        {
            int count = 0;
            string[] arr = values.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                if (db.IndexOf(arr[i]) != -1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}