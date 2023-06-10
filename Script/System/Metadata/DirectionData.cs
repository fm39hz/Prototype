using Godot;
using Utility.Direction;
using System.Collections.Generic;

namespace Metadata.Direction;
	public class DirectionData{
		public Dictionary<int, Vector2> DirectionContainer{get; private set;} = new(8);
		public int AsNumber{get; private set;}
		public Vector2 AsVector{get; private set;}
        public DirectionData(){
			DirectionContainer.Add(0, Vector2.Down);
			DirectionContainer.Add(1, Vector2.Down + Vector2.Right);
			DirectionContainer.Add(2, Vector2.Right);
			DirectionContainer.Add(3, Vector2.Right + Vector2.Up);
			DirectionContainer.Add(4, Vector2.Up);
			DirectionContainer.Add(5, Vector2.Up + Vector2.Left);
			DirectionContainer.Add(6, Vector2.Left);
			DirectionContainer.Add(7, Vector2.Left + Vector2.Down);
			}
		public void SetDirection(int input){
			this.AsNumber = input;
			this.AsVector = DirectionConverter.ToDirection(input);
			}
		public void SetDirection(Vector2 input){
			this.AsVector = input;
			this.AsNumber = DirectionConverter.ToDirection(input);
			}
		}
