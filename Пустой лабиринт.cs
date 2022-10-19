namespace Mazes
{
	/// <summary>
    /// Класс прокладыввет маршрут для робота в пустом лабиринте
    /// </summary>
    public static class EmptyMazeTask
	{
        //  левый верхний угол с координатами (1, 1), правый нижний с координатами (width - 2, height - 2).

		/// <summary>
        /// Метод перемещает робота в конечную точку лабиринта
        /// </summary>
        /// <param name="robot">Объект который перемещается</param>
        /// <param name="width">Ширина лабиринта</param>
        /// <param name="height">Высота Лабиринта</param>
        public static void MoveOut(Robot robot, int width, int height)
        {
            Move(robot, width, Direction.Right);
            Move(robot, height, Direction.Down);
        }

        /// <summary>
        /// Метод перещает робота в определенную сторону на некоторое расстояние
        /// </summary>
        /// <param name="robot">Объект который перемещается</param>
        /// <param name="pathLength">Длина пути перемещения</param>
        /// <param name="direction">Направление перемещения</param>
        private static void Move(Robot robot, int pathLength, Direction direction)
        {
            for (int i = 1; i < pathLength - 2; i++)
            {
                robot.MoveTo(direction);
            }
        }
	}
}
