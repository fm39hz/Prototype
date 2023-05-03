using Godot;
using System.Collections.Generic;

namespace Management.Direction{
	public class DirectionManager{
		private Dictionary<int, Vector2> Direction = new(8);
		public DirectionManager(){
			Direction.Add(0, Vector2.Down);
			Direction.Add(1, Vector2.Down + Vector2.Right);
			Direction.Add(2, Vector2.Right);
			Direction.Add(3, Vector2.Right + Vector2.Up);
			Direction.Add(4, Vector2.Up);
			Direction.Add(5, Vector2.Up + Vector2.Left);
			Direction.Add(6, Vector2.Left);
			Direction.Add(7, Vector2.Left + Vector2.Down);
			}
		public int GetDirectionNumber(Vector2 input){
			int _target = 0;
				foreach (KeyValuePair<int, Vector2> direction in Direction){
					if (input.AngleTo(direction.Value) == 0){
						_target = direction.Key;
						break;
						}
					}
			return _target;
			}
		public Vector2 GetDirectionVector(int input){
			Vector2 _target = Vector2.Zero;
				foreach (KeyValuePair<int, Vector2> direction in Direction){
					if (input == direction.Key){
						_target = direction.Value.Normalized();
						break;
						}
					}
			return _target;
			}
		}
	}
