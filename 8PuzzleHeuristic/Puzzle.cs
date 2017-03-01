using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace PuzzleHeuristic{
	public class Tile{
		public int x;
		public int y;
		public int w;

		public Tile(int a, int b, int c){
			x = a;
			y = b;
			w = c;
		}
	}

	public class Puzzle{
		//Instantiate list of tiles and number of displaced tiles
		List<Tile> list;
		int displacedTiles = 0;
		int loops = 0;

		public Puzzle(int v, int w){

			//Create number of tiles according to input
			list = new List<Tile>();
			/*
			for (int i = 0; i < v; i++)
				for (int j = 0; j < w; j++) {
					list.Add(new Tile (i, j));
					Console.WriteLine ("I: " + i);
					Console.WriteLine ("J: " + j);
				}*/
		}

		public void addTile(int i, int j, int wgt){

			//Create Tile Object
			Tile sp = new Tile(i, j, wgt);
			//Add spot to Puzzle array
			list.Add(sp);

			Console.WriteLine("Added edge to vertex: (" + i + ", " + j + ") with weight " + wgt);
		}

		public void printTiles(){
			int count = 0;
			foreach(Tile item in list){
				if (count == 3) {
					Console.Write ("\n");
					count = 0;
				}
				Console.Write (item.w + " ");
				count++;

			}
		}

		public void search(){
			List<Tile> openList = new List<Tile> {list[0]};
			List<Tile> closedList = new List<Tile>();

			while (openList.Count > 0) {
				loops++;


				Tile currentTile = openList.First();

				openList.Remove(currentTile);
				closedList.Add(currentTile);

				//if (successor.w == 8)
					//break;
					//        successor.g = q.g + distance between successor and q
					//        successor.h = distance from goal to successor
					//        successor.f = successor.g + successor.h
			}
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
				//Console.WriteLine ("Line " + counter + ": " + line);
				lines.Add (line);
				counter++;
			}

			int count1 = 0;
			int count2 = 0;
			foreach(string words in lines){
				string[] w = words.Split(' ');
				p.addTile (count1, count2, Int32.Parse(w[0]));
				count2++;
				p.addTile (count1, count2, Int32.Parse(w[1]));
				count2++;
				p.addTile (count1, count2, Int32.Parse(w[2]));
				count2 = 0;
				count1++;
			}
			p.printTiles ();

			file.Close();

		}
	}
}
