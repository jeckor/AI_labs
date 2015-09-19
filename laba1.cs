using System;
using System.Collections.Generic;

namespace Лаба1
{
    class Program
    {
        static void Main(string[] args)
        {
            Obj ob1 = new Obj();
            Obj ob2 = new Obj();
            Procces pr = new Procces();
            Work work = new Work();

            Console.Write("Имя первого объекта?: ");
            ob1.name = Console.ReadLine();
            Console.Write("\nИмя второго объекта?: ");
            ob2.name = Console.ReadLine();
            //вводим атрибуты последовательно для каждого объекта
            pr.Attributtes_In(ob1, ob2);
            //выводим список атрибутов обоих объектов
            pr.Attributtes_Out(ob1, ob2);
            //бесконечный цикл, в котором происходит обучение программы
            while (true)
            {
      start:    Console.Write("\nРежим работы?\n1 - запись априорной информации\n2 - режим обучения с учителем\n3 - режим распознавания\n4 - режим распознавания с самообучением\n5 - конец работы с программой\n\n-> ");
                int choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        #region запись априорной информации
                        pr.Clear_Obj(ob1);
                        pr.Clear_Obj(ob2);
                        pr.Attributtes_In(ob1, ob2);
                        break;
                        #endregion
                    case 2:
                        #region режим обучения с учителем
                        work.WithTeacher(ref ob1, ref ob2);
                        break;
                        #endregion
                    case 3:
                        #region режим распознавания
                        work.Recognition(ob1, ob2);
                        break;
                        #endregion
                    case 4:
                        #region режим режим распознавания с самообучением
                        work.Itself(ref ob1, ref ob2);
                        break;
                        #endregion
                    case 5:
                        #region конец работы с программой
                        goto exit;
                        #endregion
                    default:
                        #region не выбран не один из вариантов - запрашиваем пользователя снова
                        goto start;
                        #endregion
                }
            }
        exit:
            { }
        }
    }
    class Procces   //набор общих методов
    {
        public void Attributtes_In(Obj ob1, Obj ob2)
        {
            Obj templ;
            for (int obj = 1; obj <= 2; obj++)  
            {
                Console.WriteLine("\nВведите атрибуты " + obj + "-ого объекта и Enter в конце");
                for (int temp = 1; temp <= 10; temp++)
                {
                    Console.Write("Введите атрибут " + temp + "? (тип статистической обр. название характеритсика)\n->");
                    string temp2 = Console.ReadLine();
                    if (temp2.Length == 0)
                        break;
                    else
                    {
                        string[] temp3 = new string[3];
                        temp3 = temp2.Split(' ');
                        if (obj == 1)
                            templ = ob1;
                        else
                            templ = ob2;
                        templ.stat_attr.Add(int.Parse(temp3[0]));
                        templ.name_attr.Add(temp3[1]);
                        templ.amount_attr.Add(temp3[2]);
                    }
                }
            }
        }   //ввод атрибутов объектов
        public void Attributtes_Out(Obj ob1, Obj ob2)
        {
            Console.WriteLine("\n\nСписок 1 (" + ob1.name + ")");
            for (int i = 0; i < ob1.stat_attr.Count; i++)
            {
                Console.WriteLine(ob1.stat_attr[i] + " " + ob1.name_attr[i] + " " + ob1.amount_attr[i]);
            }
            Console.WriteLine("\n\nСписок 2 (" + ob2.name + ")");
            for (int i = 0; i < ob2.stat_attr.Count; i++)
            {
                Console.WriteLine(ob2.stat_attr[i] + " " + ob2.name_attr[i] + " " + ob2.amount_attr[i]);
            }
            Console.WriteLine("\n");
        }   //вывод атрибутов объектов
        public void Clear_Obj(Obj obj)
        {
            obj.stat_attr.Clear();
            obj.name_attr.Clear();
            obj.amount_attr.Clear();
        }   //очищает атрибуты объекта
    }
    class Work  //методы, реализующие различные режимы обучения
    {
        public void WithTeacher(ref Obj ob1, ref Obj ob2)   //режим обучения с учителем
        {
            while (true)
            {
                List<int> stat_temp = new List<int>();
                List<string> name_temp = new List<string>();
                List<string> amount_temp = new List<string>();

                Console.WriteLine("\nВведите атрибуты любого объекта и Enter в конце");
                for (int temp = 1; temp <= 10; temp++)
                {
                    Console.Write("Введите атрибут " + temp + "? (тип статистической обр. название характеритсика)\n->");
                    string temp2 = Console.ReadLine();
                    if (temp2.Length == 0)
                        break;
                    else
                    {
                        string[] temp3 = new string[3];
                        temp3 = temp2.Split(' ');    
                        stat_temp.Add(int.Parse(temp3[0]));
                        name_temp.Add(temp3[1]);
                        amount_temp.Add(temp3[2]);
                    }
                }
                #region Определяем объект на основе введенной информации
                Obj win;
                int F1 = 0, F2 = 0; //оценочные функции
                for (int j = 0; j < name_temp.Count; j++)
                {
                    if (ob1.name_attr.Contains(name_temp[j]))
                        F1++;
                    if (ob2.name_attr.Contains(name_temp[j]))
                        F2++;
                }
                if (F1 >= F2)
                {
                    Console.WriteLine("\nЭто " + ob1.name + "? ");
                    string temp = Console.ReadLine();
                    if (temp == "Да" || temp == "да")
                        win = ob1;
                    else
                        win = ob2;
                }
                else
                {
                    Console.WriteLine("\nЭто " + ob2.name + "? ");
                    string temp = Console.ReadLine();
                    if (temp == "Да" || temp == "да")
                        win = ob2;
                    else
                        win = ob1;
                }
                #endregion

                #region Добавляем новые атрибуты
                for (int j = 0; j < name_temp.Count; j++)
                    if (!win.name_attr.Contains(name_temp[j]))
                    {
                        win.stat_attr.Add(stat_temp[j]);
                        win.name_attr.Add(name_temp[j]);
                        win.amount_attr.Add(amount_temp[j]);
                    }
                #endregion

                #region Обрабатываем уже имеющиеся
                for(int i = 0; i < win.name_attr.Count; i++)
                    for (int j = 0; j < name_temp.Count; j++)
                    {
                        if (win.name_attr[i] == name_temp[j])
                        {
                            if (win.stat_attr[i] == 0)
                                win.amount_attr[i] = amount_temp[j];
                            else if (win.stat_attr[i] == 1 || win.stat_attr[i] == 2)
                            {
                                int a1 = int.Parse(win.amount_attr[i]);
                                int a2 = int.Parse(amount_temp[j]);
                                int S = (a1 + a2) / 2;
                                win.amount_attr[i] = Convert.ToString(S);
                            }
                            else
                            {
                                if (!win.amount_attr[i].Contains(","))
                                {
                                    int a1 = int.Parse(win.amount_attr[i]);
                                    int a2 = int.Parse(amount_temp[j]);
                                    if (a1 > a2)
                                    {
                                        string res = a2 + "," + a1;
                                        win.amount_attr[i] = res;
                                    }
                                    else if (a1 < a2)
                                    {
                                        string res = a1 + "," + a2;
                                        win.amount_attr[i] = res;
                                    }
                                    else if (a1 == a2)
                                        continue;
                                }
                                else
                                {
                                    string[] nums = win.amount_attr[i].Split(',');
                                    int a1 = int.Parse(nums[0]);
                                    int a2 = int.Parse(nums[1]);
                                    int a3 = int.Parse(amount_temp[j]);
                                    if (a3 > a1 && a3 < a2)
                                        continue;
                                    else if (a3 > a2)
                                    {
                                        string res = a1 + "," + a3;
                                        win.amount_attr[i] = res;
                                    }
                                    else if (a3 < a1)
                                    {
                                        string res = a3 + "," + a2;
                                        win.amount_attr[i] = res;
                                    }
                                }
                            }
                        }
                    }
                #endregion

                #region Выводим обновленный список атрибутов
                Procces pr = new Procces();
                pr.Attributtes_Out(ob1, ob2);
                #endregion

                Console.WriteLine("\nРежим обучения продолжается? ");
                string cont = Console.ReadLine();
                if (cont == "Да" || cont == "да")
                    continue;
                else
                    break;
            }
        }
        public void Recognition(Obj ob1, Obj ob2)   //режим распознавания
        {
            while (true)
            {
                List<int> stat_temp = new List<int>();
                List<string> name_temp = new List<string>();
                List<string> amount_temp = new List<string>();

                Console.WriteLine("\nВведите атрибуты любого объекта и Enter в конце");
                for (int temp = 1; temp <= 10; temp++)
                {
                    Console.Write("Введите атрибут " + temp + "? (тип статистической обр. название характеритсика)\n->");
                    string temp2 = Console.ReadLine();
                    if (temp2.Length == 0)
                        break;
                    else
                    {
                        string[] temp3 = new string[3];
                        temp3 = temp2.Split(' ');
                        stat_temp.Add(int.Parse(temp3[0]));
                        name_temp.Add(temp3[1]);
                        amount_temp.Add(temp3[2]);
                    }
                }
                #region Определяем объект на основе введенной информации
                int F1 = 0, F2 = 0; //оценочные функции
                for (int j = 0; j < name_temp.Count; j++)
                {
                    if (ob1.name_attr.Contains(name_temp[j]))
                        F1++;
                    if (ob2.name_attr.Contains(name_temp[j]))
                        F2++;
                }
                if (F1 >= F2)
                    Console.WriteLine("\nЭто " + ob1.name + "!");
                else
                    Console.WriteLine("\nЭто " + ob2.name + "! ");
                #endregion

                Console.WriteLine("\nРежим распознавания продолжается? ");
                string cont = Console.ReadLine();
                if (cont == "Да" || cont == "да")
                    continue;
                else
                    break;
            }
        }
        public void Itself(ref Obj ob1, ref Obj ob2)        //режим распознавания с самообучением
        {
            while (true)
            {
                List<int> stat_temp = new List<int>();
                List<string> name_temp = new List<string>();
                List<string> amount_temp = new List<string>();

                Console.WriteLine("\nВведите атрибуты любого объекта и Enter в конце");
                for (int temp = 1; temp <= 10; temp++)
                {
                    Console.Write("Введите атрибут " + temp + "? (тип статистической обр. название характеритсика)\n->");
                    string temp2 = Console.ReadLine();
                    if (temp2.Length == 0)
                        break;
                    else
                    {
                        string[] temp3 = new string[3];
                        temp3 = temp2.Split(' ');
                        stat_temp.Add(int.Parse(temp3[0]));
                        name_temp.Add(temp3[1]);
                        amount_temp.Add(temp3[2]);
                    }
                }
                #region Определяем объект на основе введенной информации
                Obj win;
                int F1 = 0, F2 = 0; //оценочные функции
                for (int j = 0; j < name_temp.Count; j++)
                {
                    if (ob1.name_attr.Contains(name_temp[j]))
                        F1++;
                    if (ob2.name_attr.Contains(name_temp[j]))
                        F2++;
                }
                if (F1 >= F2)
                {
                    Console.WriteLine("\nЭто " + ob1.name + "! ");
                    win = ob1;
                }
                else
                {
                    Console.WriteLine("\nЭто " + ob2.name + "! ");
                    win = ob2;
                }
                #endregion

                #region Добавляем новые атрибуты
                for (int j = 0; j < name_temp.Count; j++)
                    if (!win.name_attr.Contains(name_temp[j]))
                    {
                        win.stat_attr.Add(stat_temp[j]);
                        win.name_attr.Add(name_temp[j]);
                        win.amount_attr.Add(amount_temp[j]);
                    }
                #endregion

                #region Обрабатываем уже имеющиеся
                for (int i = 0; i < win.name_attr.Count; i++)
                    for (int j = 0; j < name_temp.Count; j++)
                    {
                        if (win.name_attr[i] == name_temp[j])
                        {
                            if (win.stat_attr[i] == 0)
                                win.amount_attr[i] = amount_temp[j];
                            else if (win.stat_attr[i] == 1 || win.stat_attr[i] == 2)
                            {
                                int a1 = int.Parse(win.amount_attr[i]);
                                int a2 = int.Parse(amount_temp[j]);
                                int S = (a1 + a2) / 2;
                                win.amount_attr[i] = Convert.ToString(S);
                            }
                            else
                            {
                                if (!win.amount_attr[i].Contains(","))
                                {
                                    int a1 = int.Parse(win.amount_attr[i]);
                                    int a2 = int.Parse(amount_temp[j]);
                                    if (a1 > a2)
                                    {
                                        string res = a2 + "," + a1;
                                        win.amount_attr[i] = res;
                                    }
                                    else if (a1 < a2)
                                    {
                                        string res = a1 + "," + a2;
                                        win.amount_attr[i] = res;
                                    }
                                    else if (a1 == a2)
                                        continue;
                                }
                                else
                                {
                                    string[] nums = win.amount_attr[i].Split(',');
                                    int a1 = int.Parse(nums[0]);
                                    int a2 = int.Parse(nums[1]);
                                    int a3 = int.Parse(amount_temp[j]);
                                    if (a3 > a1 && a3 < a2)
                                        continue;
                                    else if (a3 > a2)
                                    {
                                        string res = a1 + "," + a3;
                                        win.amount_attr[i] = res;
                                    }
                                    else if (a3 < a1)
                                    {
                                        string res = a3 + "," + a2;
                                        win.amount_attr[i] = res;
                                    }
                                }
                            }
                        }
                    }
                #endregion

                #region Выводим обновленный список атрибутов
                Procces pr = new Procces();
                pr.Attributtes_Out(ob1, ob2);
                #endregion

                Console.WriteLine("\nРежим обучения продолжается? ");
                string cont = Console.ReadLine();
                if (cont == "Да" || cont == "да")
                    continue;
                else
                    break;
            }
        }
    }
    class Obj   //класс, реализующий объект
    {
        public string name; 
        public List<int> stat_attr = new List<int>();
        public List<string> name_attr = new List<string>();
        public List<string> amount_attr = new List<string>();
    }
}
