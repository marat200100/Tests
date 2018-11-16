using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Tests.Models;

namespace Tests.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Check(string Name, int weight, int growth, int age, string vision, string Med)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Test _test = new Test();
            int[] arr = new int[10];

            arr[0] = _test.GetByInterval(weight, 70, 75, 90, 100);
            arr[1] = _test.GetByInterval(growth, 160, 170, 185, 190);
            arr[2] = _test.GetByInterval(age, 23, 25, 35, 37);
            arr[3] = _test.Vision(Convert.ToDouble(vision));
            arr[4] = _test.Smoking(Med);
            arr[5] = !String.IsNullOrEmpty(Med) ? _test.Therapist(Med, string.Join(" ", db.Therapists.Select(x => x.Name).ToArray())) : 0;
            arr[6] = !String.IsNullOrEmpty(Med) ? _test.Psychiatrist(Med, string.Join(" ", db.Psychiatrists.Select(x => x.Name).ToArray())) : 0;
            arr[7] = _test.Test1(weight, (arr[4] == 0), Med);
            arr[8] = _test.Test2(Name, age);
            arr[9] = _test.Test3(Med, growth);

            string res = string.Join(" ", arr.Select(x => x.ToString()).ToArray());

            StringBuilder sb = new StringBuilder();

            if ((res.Length - res.Replace("2", "").Length >= 1) || (res.Length - res.Replace("1", "").Length >= 3))
            {
                sb.Append("Кандидат " + Name + " не прошел тестирование. Проблемы:<br/>");
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == 1) sb.Append(Decline(i) + "(удовлетворительно)<br/>");
                    else if (arr[i] == 2) sb.Append(Decline(i) + "(неудовлетворительно)<br/>");
                }
                return sb.ToString();
            }
            else return "Кандидат " + Name + " подходит";
        }

        public string Decline(int i)
        {
            switch (i)
            {
                case 0:
                    return "* Вес кандидата ";
                case 1:
                    return "* Рост кандидата ";
                case 2:
                    return "* Возраст кандидата ";
                case 3:
                    return "* Зрение кандидата ";
                case 4:
                    return "* Кандидат курит ";
                case 5:
                    return "* Терапевт: по болезням ";
                case 6:
                    return "* Психолог:  по болезням ";
                case 7:
                    return "* Тест <<Вес и вредные привычки>>: ";
                case 8:
                    return "* Тест <<Странный>>: ";
                case 9:
                    return "* Тест <<Математический>>: ";
                default:
                    return "* Кандидат не подходит";
            }
        }
    }
}