using Godot;
using System;

namespace Component{
    public class FrameComponent{
        public FrameComponent(int _frameNumber, int _stateNumber, double _delta){
            Length = _frameNumber;
            State = _stateNumber;
            RelativeTimeResponse = 60 * _delta;
            }
        public int Length{get; set;}
        public int State{get; set;}
        public int Direction{get; set;}
        public double RelativeTimeResponse{get; set;}
        public void GetDirection(Vector2 _input){
            int _angleNumb = Convert.ToInt32(Math.Round(_input.Angle() / Mathf.Pi * 180));
                if (_angleNumb <= 0){
                    _angleNumb *= -1;
                    }
                else{
                    _angleNumb = -(_angleNumb - 360);
                    }
            if (_input != Vector2.Zero){
                Direction = _angleNumb / 45;
                }
            }
        }
    }