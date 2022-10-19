namespace Mazes
{
	/// <summary>
    /// Класс прокладыввет маршрут для робота в лабиринте типа snake
    /// </summary>
    public static class SnakeMazeTask
	{
        /// <summary>
        /// Метод перемещает робота в конечную точку лабиринта
        /// </summary>
        /// <param name="robot">Объект который перемещается</param>
        /// <param name="width">Ширина лабиринта</param>
        /// <param name="height">Высота Лабиринта</param>
		public static void MoveOut(Robot robot, int width, int height)
		{
            // перемещение выполняется, пока робот не дойдет до конца
            while (!robot.Finished)
            {
                Move(robot, width, Direction.Right);
                Move(robot, 5, Direction.Down);
                Move(robot, width, Direction.Left);
                if (!robot.Finished)
                {
                    Move(robot, 5, Direction.Down);
                }             
            }         
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
