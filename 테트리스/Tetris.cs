﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 테트리스
{
	class Tetris
	{
		public int[,] _grid = new int[20, 10];
		public int _blockSize = 20;

		public Tetris()
		{

		}

		public void add_block(int[,] blk, int x, int y)
		{
			int rows = blk.GetLength(0);
			int cols = blk.GetLength(1);

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					_grid[r + y, c + x] = blk[r, c];
				}
			}
		}

		public int[,] shift(int[,] grid, int x, int y)
		{
			int sum_grid = sum(grid);

			int rows = grid.GetLength(0);
			int cols = grid.GetLength(1);
			int[,] clone = new int[rows, cols];

			for (int r = 0; r < rows; r++)
			{
				if (r + y < 0 || r + y >= rows) continue;

				for (int c = 0; c < cols; c++)
				{
					if (c + x < 0 || c + x >= cols) continue;

					clone[r + y, c + x] = grid[r, c];
				}
			}

			int sum_clone = sum(clone);
			if (sum_grid == sum_clone) return clone;
			else return grid;
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
			int rows = _grid.GetLength(0);
			int cols = _grid.GetLength(1);

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					if (_grid[r, c] != 0)
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