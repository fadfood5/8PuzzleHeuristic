using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace PuzzleHeuristic{
	public class Spot{
		public int x;
		public int y;

		public Spot(int a, int b){
			x = a;
			y = b;
		}
	}

	public class Puzzle{
		//Instantiate list of nodes and number of vertices
		Spot[] list;
		public List<int> nodes;

		public Puzzle(int v, int w){
			nodes = new List<int>();
			//Create number of Spots according to input
			list = new Spot[v];
			for (int i = 0; i < v; i++)
				for (int j = 0; j < w; j++) {
					list [i] = new Spot (i, j);
					Console.WriteLine ("I: " + i);
					Console.WriteLine ("J: " + j);
				}
		}

		public static void Main(string[] args){
			Puzzle p = new Puzzle (3, 3);
		}
	}
}
