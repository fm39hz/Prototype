using Godot;
using System;

namespace Component.Animation{
    public class FrameInfo{
        public FrameInfo(int _frameNumber, int _stateNumber, double _speed){
            Length = _frameNumber;
            State = _stateNumber;
            Speed = _speed;
            }
        public int Length{get; set;}
        public int State{get; set;}
        public int Facing{get; set;}
        public double Speed{get; set;}
        public void GetDirectionFacing(Vector2 input){
            int _angleNumb = Convert.ToInt32(Math.Round(input.Angle() / Mathf.Pi * 180) - 90);
                 if (!input.IsEqualApprox(Vector2.Zero)){
                     Facing = (8 - (_angleNumb / 45)) % 8;
                        }
            }
            public static double GetRelativeResponseTime(double delta){
                return 60 * delta;
                }
        }
    }