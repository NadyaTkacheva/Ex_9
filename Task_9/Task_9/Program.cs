using System;
using System.IO;

namespace Task_9
{
   /// <summary>
     /// класс для однонаправленного списка
     /// </summary>
        class Point
        {
            public int data;//информационное поле
            public Point next;//адресное поле

            public Point(int d)//конструктор с параметрами
            {
                data = d;
                next = null;
            }
            public Point()//конструктор без параметра
            {
                data = 0;
                next = null;
            }
            //перегрузка для вывода
            public override string ToString()
            {
                return data + " ";
            }

        }
    class Program
    {
        /// <summary>
        /// поиск элемента
        /// </summary>
        /// <param name="beg"></param>
        /// <param name="find"></param>
        /// <returns></returns>
        static Point Search(Point beg, int find)
        {
            Point r = beg;//вспом. переменная для прохода по списку
            Point el = new Point(find);
            bool ok = true;

            while (r.next != null)//идем по списку до нужного элемента
            {
                if (el.data == r.data)
                {
                    Console.WriteLine("Элемент {0} найден \n ", el);
                    ok = false;
                    break;
                }
                r = r.next;
            }

            if (ok == true)//элемент не найден
            {
                Console.WriteLine("Ошибка! Элемент {0}  не найден \n", el);
                
            }

            return beg;
        }
            /// <summary>
            /// удаление элемента
            /// </summary>
            /// <param name="beg"></param>
            /// <param name="del"></param>
            /// <returns></returns>
        static Point Delete(ref Point beg, int del)
        {
            Point el = new Point(del);
            bool ok = true;
            if (beg == null)//пустой список
            {
                Console.WriteLine("Элементов в списке нет.");
                return null;
            }            
            Point r = beg;
            //ищем элемент для удаления 
            while (r.next != null)//идем по списку до нужного элемента
            {
                if (el.data == r.data)
                {
                    r = r.next;
                    ok = false;
                    Console.WriteLine("Элемент {0} удален\n", el);
                    break;
                }
                r = r.next;
            }
            if (el.data==beg.data)
            {
                beg = r;
            }
            if (ok==true)//элемент не найден
            {
                Console.WriteLine("Ошибка! Элемент {0}  не найден \n", el);                
            }

            return beg;
        }
       /// <summary>
       /// формирование списка
       /// </summary>
       /// <param name="beg"></param>
       /// <param name="info"></param>
       /// <returns></returns>
        static Point AddPoint(Point beg, int info)
        {                 
            Point r = beg;
            Point p = new Point(info);  //создаем новый элемент           
            if (beg == null)//список пустой
            {
                beg = p;
                return beg;
            }
            if (p.data > 0) //добавление в начало списка
            {
                p.next = beg;
                beg = p;
                return p;
            }
            if (p.data < 0)// добавляем в конец
            {
                while (r.next != null)
                    r = r.next;
                 r.next = p;
                r = p;
            }
            if (p.data == 0)//вставляем новый элемент 
            {
                while ( r.next!= null )
                {                   
                    if (r.next.data < 0)
                    {
                        p.next = r.next;
                        r.next = p;
                        break;
                    }
                    r = r.next;
                }        
            }
            return beg;
        }
        
       /// <summary>
       /// чтение элементов из файла
       /// </summary>
        public static Point ReadFile()
            {
            
            Point beg = null;
            FileStream doc = new FileStream("input.txt", FileMode.Open); //создаем файловый поток           
            StreamReader myWriter = new StreamReader(doc);
                    
               try
                 {
                   string[] file = myWriter.ReadToEnd().Split(' ','\n');  
                
                   for (int i = 0; i <file.Length; i++)
                   beg=AddPoint(beg, Convert.ToInt16(file[i]));
                  
                 }

               catch (Exception ex)
                {
                   Console.WriteLine(ex.Message);
                }

               finally
                {
                    myWriter.Close();
                }

            doc.Close();
            ShowList(beg);
            return beg;
        }

            /// <summary>
            /// вывод списка
            /// </summary>
            /// <param name="beg"></param>
            static void ShowList(Point beg)
            {
                //проверка наличия элементов в списке
                if (beg == null)
                {
                    Console.WriteLine("Элементов в списке нет.");
                    return;
                }
                Point p = beg;
                while (p != null)
                {
                    Console.Write(p);
                    p = p.next;//переход к следующему элементу
                }
                Console.WriteLine();
            }
           
            
            static void Main(string[] args)
            { Point beg = new Point();
                beg = ReadFile();
            //пример поиска эл-тов
            Console.Write("Поиск элемента 10: ");
            Search(beg, 10);
            Console.Write("Поиск элемента 35: ");
            Search(beg, 35);
            //пример удаления эл-тов
            Console.Write("Удаление элемента 4: ");           
            ShowList(Delete(ref beg, 5));
            Console.Write("Удаление элемента 100: ");
            ShowList(Delete(ref beg, 100));
            Console.ReadKey();
            }
        }
    }


