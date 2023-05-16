using Godot;
using Modifier.Direction;
using System.Collections.Generic;

namespace Metadata.Direction{
	public class DirectionMetadata{
		public Dictionary<int, Vector2> Direction{get; private set;} = new(8);
		public int AsNumber{get; private set;}
		public Vector2 AsVector{get; private set;}
        public DirectionMetadata(){
			Direction.Add(0, Vector2.Down);
			Direction.Add(1, Vector2.Down + Vector2.Right);
			Direction.Add(2, Vector2.Right);
			Direction.Add(3, Vector2.Right + Vector2.Up);
			Direction.Add(4, Vector2.Up);
			Direction.Add(5, Vector2.Up + Vector2.Left);
			Direction.Add(6, Vector2.Left);
			Direction.Add(7, Vector2.Left + Vector2.Down);
			}
		public void SetDirection(int input){
			this.AsNumber = input;
			this.AsVector = Convert.ToDirection(input);
			}
		public void SetDirection(Vector2 input){
			this.AsVector = input;
			this.AsNumber = Convert.ToDirection(input);
			}
		}
	}
