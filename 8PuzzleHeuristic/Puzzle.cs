using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace PuzzleHeuristic{
	public class Spot{
		public int x;
		public int y;
		public int w;

		public Spot(int a, int b, int c){
			x = a;
			y = b;
			w = c;
		}
	}

	public class Puzzle{
		//Instantiate list of nodes and number of vertices
		List<Spot> list;

		public Puzzle(int v, int w){

			//Create number of Spots according to input
			list = new List<Spot>();
			/*
			for (int i = 0; i < v; i++)
				for (int j = 0; j < w; j++) {
					list.Add(new Spot (i, j));
					Console.WriteLine ("I: " + i);
					Console.WriteLine ("J: " + j);
				}*/
		}

		public void addSpot(int i, int j, int wgt){

			//Create Spot Object
			Spot sp = new Spot(i, j, wgt);
			//Add spot to Puzzle array
			list.Add(sp);

			Console.WriteLine("Added edge to vertex: (" + i + ", " + j + ") with weight " + wgt);
		}

		public static void Main(string[] args){
			Puzzle p = new Puzzle (3, 3);

			Console.WriteLine ("\nWhat is the name of your .txt file? Make sure it is in the current directory and that there are no whitespace lines. Do not insert the .txt extension.");
			var b = Console.ReadLine ();

			string line;
			int counter = 0;
			System.IO.StreamReader file = new System.IO.StreamReader("../../" + b + ".txt");
			List<string> lines = new List<string> ();
			while((line = file.ReadLine()) != null){
				Console.WriteLine ("Line " + counter + ": " + line);
				lines.Add (line);
				counter++;
			}

			int count1 = 0;
			int count2 = 0;
			foreach(string words in lines){
				string[] w = words.Split(' ');
				p.addSpot (count1, count2, Int32.Parse(w[0]));
				count2++;
				p.addSpot (count1, count2, Int32.Parse(w[1]));
				count2++;
				p.addSpot (count1, count2, Int32.Parse(w[2]));
				count2 = 0;
				count1++;
			}

			file.Close();

		}
	}
}
