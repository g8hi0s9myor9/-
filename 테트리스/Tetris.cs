using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 테트리스
{
	class Tetris
	{
		int[,] _grid = new int[20, 10];
		int[,] _grid_history = new int[20, 10];
		int _blockSize = 20;

		public Tetris()
		{
			
		}

		public bool shift(int x, int y)
		{
			int sum_grid = sum(_grid);

			int rows = _grid.GetLength(0);
			int cols = _grid.GetLength(1);
			int[,] clone = new int[rows, cols];

			for (int r = 0; r < rows; r++)
			{
				if (r + y < 0 || r + y >= rows) continue;

				for (int c = 0; c < cols; c++)
				{
					if (c + x < 0 || c + x >= cols) continue;

					clone[r + y, c + x] = _grid[r, c];
				}
			}

			int sum_clone = sum(clone);
			if (sum_grid == sum_clone && !colision(clone, _grid_history))
			{
				_grid = clone;
				return true;
			}
			else
			{
				return false;
			}
		}

		public void add_block()
		{
			_grid[0, 0] = 1;
			_grid[0, 1] = 1;
			_grid[0, 2] = 0;

			_grid[1, 0] = 0;
			_grid[1, 1] = 1;
			_grid[1, 2] = 1;
		}

		public void merge()
		{
			_grid_history = merge(_grid, _grid_history);
			_grid = new int[_grid.GetLength(0), _grid.GetLength(1)];
		}

		int[,] merge(int[,] arr1, int[,] arr2)
		{
			/* 0, 0 -> 0
			 * 1, 0 -> 1
			 * 0, 1 -> 1
			 * 1, 1 -> 1
			 */
			int[,] result = new int[arr1.GetLength(0), arr1.GetLength(1)];

			for (int r = 0; r < arr1.GetLength(0); r++)
			{
				for (int c = 0; c < arr1.GetLength(1); c++)
				{
					if (arr1[r, c] == 0 && arr2[r, c] == 0)
					{
						result[r, c] = 0;
					}
					else result[r, c] = 1;
				}
			}

			return result;
		}

		bool colision(int[,] arr1, int[,] arr2)
		{
			/* 0, 0 -> 0
			 * 0, 1 -> 0
			 * 1, 0 -> 0
			 * 1, 1 -> 1
			 */

			for (int r = 0; r < arr1.GetLength(0); r++)
			{
				for (int c = 0; c < arr1.GetLength(1); c++)
				{
					if(arr1[r,c] > 0 && arr2[r,c] > 0)
					{
						return true;
					}
				}
			}

			return false;
		}

		int sum(int[,] arr)
		{
			int rows = arr.GetLength(0);
			int cols = arr.GetLength(1);
			int i = 0;

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					i += arr[r, c];
				}
			}

			return i;
		}

		public void draw(Graphics g)
		{
			int[,] tmp = merge(_grid, _grid_history);

			int rows = _grid.GetLength(0);
			int cols = _grid.GetLength(1);

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					if (tmp[r, c] != 0)
					{
						g.FillRectangle(
							Brushes.Black,
							c * _blockSize,
							r * _blockSize,
							_blockSize,
							_blockSize
						);
					}
					else
					{
						g.DrawRectangle(
							Pens.Black,
							c * _blockSize,
							r * _blockSize,
							_blockSize,
							_blockSize
						);
					}
				}
			}
		}
	}
}

//todo shift() public 없애기