using System;

namespace Names
{
    /// <summary>
    /// Класс для подготовки данных для тепловой карты рождаемости
    /// </summary>
    internal static class HeatmapTask
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
                days[i] = (i + 2).ToString();
            return days;
        }
        /// <summary>
        /// Метод генерирует номера месяца в году
        /// </summary>
        /// <param name="months">массив с номерами месяцев в году</param>
        /// <returns>массив, заполненный номерами месяцев в году</returns>
        public static string[] GenerateNumberMonthInYear(string[] months)
        {
            // заполняем массив months от 1 до 12 (номер месяца в году)
            for (var i = 0; i < months.Length; i++)
                months[i] = (i + 1).ToString();
            return months;
        }
        /// <summary>
        /// Метод подготавливать данные для тепловой карты рождаемости в зависимости от дня и месяца
        /// </summary>
        /// <param name="names">База данных</param>
        /// <returns>Метод для визуализации данных на диаграмме</returns>
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var days = new string[30]; // массив хранит номер дня (на оси x)
            var months = new string[12]; // массив хранит номер месяца (на оси y)

            // двумерный массив для хранения количетва родившихся в определенный день и месяц
            var birthDates = new double[days.Length, months.Length];
            foreach (var item in names)
            {
                // если номер дня в месяце не равен одному (по условию)
                if (item.BirthDate.Day != 1)
                    // увеличиваем занчение номера дня в определенном месяце,когда родился человек
                    birthDates[item.BirthDate.Day - 2, item.BirthDate.Month - 1] += 1;
            }

            // визуализируем данные на диаграмме
            return new HeatmapData(
                "Пример карты интенсивностей",
                birthDates, 
                GenerateNumberDayInMonth(days), 
                GenerateNumberMonthInYear(months)
                );
        }
    }
}
