using Godot;
using System.Collections.Generic;
using Metadata.Instance;

namespace Utility.Direction;
		public static class DirectionConverter{
			public static int ToDirection(Vector2 input){
				var _directionMap = new DirectionData().DirectionContainer;
				var _target = 0;
					foreach (KeyValuePair<int, Vector2> direction in _directionMap){
						if (input.AngleTo(direction.Value) == 0){
							_target = direction.Key;
							break;
							}
						}
				return _target;
				}
			public static Vector2 ToDirection(int input){
				var _directionMap = new DirectionData().DirectionContainer;
				var _target = Vector2.Zero;
					if (input < 0 || input > 7){
						return _target;
						}
					foreach (KeyValuePair<int, Vector2> direction in _directionMap){
						if (input == direction.Key){
							_target = direction.Value.Normalized();
							break;
							}
						}
				return _target;
				}
			}
