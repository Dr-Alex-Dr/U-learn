using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;

namespace Names
{
    /// <summary>
    /// Класс для подготовки данных для гистограммы
    /// </summary>
    internal static class HistogramTask
    {
        /// <summary>
        /// Метод генерирует номера дней в месяце
        /// </summary>
        /// <param name="days">массив с номерами дней в месяце</param>
        /// <returns>массив, заполненный номерами дней в месяце</returns>
        public static string[] GenerateNumberDayInMonth(string[] days)
        {
            // заполняем массив days от 1 до 31 (номер дня в месяце)
            for (int i = 0; i < days.Length; i++) 
                days[i] = (i+1).ToString();
            return days;
        }
        /// <summary>
        /// Метод составляет гистограмму
        /// </summary>
        /// <param name="names">База данных</param>
        /// <param name="name">Имя по которому строить гистрорамму</param>
        /// <returns>Метод для визуализации данных на диаграмме</returns>
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {                   
            string[] days = new string[31]; // массив хранит номер дня (на оси x)
            var birthDates = new double[days.Length]; // массив хранит количетво людей, родившихся в опредленный день (на оси y) 
            // перебираем все данные из базы данных 'names'
            foreach (var item in names)
            {
                // если номер дня в месяце не равен одному (по условию) и имя равно искомому имени 
                if (item.BirthDate.Day != 1 && item.Name == name)
                {
                    // увеличиваем занчение номера дня,когда родился человек
                    birthDates[item.BirthDate.Day - 1] += 1;
                }
            }
         
            // визуализируем данные на диаграмме
            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name),
                GenerateNumberDayInMonth(days),
                birthDates);
        }
    }
}
